using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Test_Final.HelperInput;  // Giả sử InputHelper được đặt ở đây.
using Test_Final.Models;
using Test_Final.Services;

public class Program
{
	private readonly IBookInventoryService _inventory;
	private readonly ILogger<Program> _logger;

	public Program(IBookInventoryService inventory, ILogger<Program> logger)
	{
		_inventory = inventory;
		_logger = logger;
	}

	public static async Task Main(string[] args)
	{
		// Cấu hình Dependency Injection và Logging.
		var serviceCollection = new ServiceCollection();
		ConfigureServices(serviceCollection);
		var serviceProvider = serviceCollection.BuildServiceProvider();

		// Lấy đối tượng Program đã được DI và chạy ứng dụng.
		var program = serviceProvider.GetRequiredService<Program>();
		await program.RunAsync();
	}

	private static void ConfigureServices(ServiceCollection services)
	{
		// Cấu hình Logging với console logger.
		services.AddLogging(builder =>
		{
			builder.AddConsole()
				   .AddDebug()
				   .SetMinimumLevel(LogLevel.Information);
		});
		// Đăng ký IBookInventoryService với implementation là BookInventoryService.
		services.AddSingleton<IBookInventoryService, BookInventoryService>();

		// Đăng ký lớp Program.
		services.AddSingleton<Program>();
	}

	public async Task RunAsync()
	{
		bool exit = false;
		while (!exit)
		{
			try
			{
				Console.WriteLine("\n========== Bookstore Inventory ==========");
				Console.WriteLine("1. Add Book");
				Console.WriteLine("2. Remove Book");
				Console.WriteLine("3. Display Books");
				Console.WriteLine("4. Search Book");
				Console.WriteLine("5. Update Book");
				Console.WriteLine("6. Sort Books");
				Console.WriteLine("7. Export to JSON");
				Console.WriteLine("8. Import from JSON");
				Console.WriteLine("9. Export to Excel");
				Console.WriteLine("10. Import from Excel");
				Console.WriteLine("11. Exit");
				Console.Write("Enter your choice: ");
				string? choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						await AddBookMenuAsync();
						break;

					case "2":
						await RemoveBookMenuAsync();
						break;

					case "3":
						await DisplayBooksMenuAsync();
						break;

					case "4":
						await SearchBookMenuAsync();
						break;

					case "5":
						await UpdateBookMenuAsync();
						break;

					case "6":
						await SortBooksMenuAsync();
						break;

					case "7":
						await ExportToJsonMenuAsync();
						break;

					case "8":
						await ImportFromJsonMenuAsync();
						break;

					case "9":
						await ExportToExcelMenuAsync();
						break;

					case "10":
						await ImportFromExcelMenuAsync();
						break;

					case "11":
						exit = true;
						Console.WriteLine("Exiting application. Goodbye!");
						break;

					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred in main loop.");
				Console.WriteLine("Error: " + ex.Message);
			}
		}
	}

	private async Task AddBookMenuAsync()
	{
		Console.WriteLine("========= Add Book =========");
		int id = InputHelper.ReadInt("Enter book id: ");
		string isbn = InputHelper.ReadString("Enter book ISBN: ", true);
		string title = InputHelper.ReadString("Enter book title: ", true);
		string author = InputHelper.ReadString("Enter book author: ", false);
		decimal price = InputHelper.ReadDecimal("Enter book price: ");
		int quantity = InputHelper.ReadInt("Enter book quantity: ", allowZero: true);

		Book book = new Book(id, isbn, title, author, price, quantity);

		try
		{
			await _inventory.AddBookAsync(book);
			Console.WriteLine("Book added successfully!");
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine("Error adding book: " + ex.Message);
		}
	}

	private async Task RemoveBookMenuAsync()
	{
		Console.WriteLine("========= Remove Book =========");
		int id = InputHelper.ReadInt("Enter book id: ");
		var book = await _inventory.GetBookAsync(id);
		if (book != null)
		{
			await _inventory.RemoveBookAsync(book);
			Console.WriteLine("Book removed successfully!");
		}
		else
		{
			Console.WriteLine("Book with ID {0} not found.", id);
		}
	}

	private async Task DisplayBooksMenuAsync()
	{
		Console.WriteLine("========= Display Books =========");
		await _inventory.DisplayBooksAsync();
	}

	private async Task SearchBookMenuAsync()
	{
		Console.WriteLine("========= Search Book =========");
		Console.Write("Enter search keyword: ");
		string? keyword = Console.ReadLine();

		if (string.IsNullOrWhiteSpace(keyword))
		{
			Console.WriteLine("Keyword cannot be empty.");
			return;
		}

		List<Book> results;
		try
		{
			results = await _inventory.SearchBookAsync(keyword);
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine("Error: " + ex.Message);
			return;
		}

		if (results.Any())
		{
			Console.WriteLine("Search Results:");
			Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10} {6,10}",
				"ID", "Title", "Author", "ISBN", "Price", "Quantity", "Available");
			foreach (var b in results)
			{
				Console.WriteLine(b.ToString());
			}
		}
		else
		{
			Console.WriteLine("No books found matching the keyword.");
		}
	}

	private async Task UpdateBookMenuAsync()
	{
		Console.WriteLine("========= Update Book =========");
		int id = InputHelper.ReadInt("Enter book id: ");
		var book = await _inventory.GetBookAsync(id);
		if (book != null)
		{
			int quantity = InputHelper.ReadInt("Enter quantity to update: ");
			try
			{
				var result = await _inventory.UpdateBookAsync(book, quantity);
				if (result.HasValue)
				{
					Console.WriteLine("Book updated successfully.");
					Console.WriteLine("New quantity: " + result.Value.Item2);
				}
				else
				{
					Console.WriteLine("Book with ID {0} not found.", id);
				}
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Console.WriteLine("Error updating book: " + ex.Message);
			}
		}
		else
		{
			Console.WriteLine("Book with ID {0} not found.", id);
		}
	}

	private async Task SortBooksMenuAsync()
	{
		Console.WriteLine("========= Sort Books =========");
		Console.WriteLine("1. Sort by Title");
		Console.WriteLine("2. Sort by Author");
		Console.WriteLine("3. Sort by Price");
		Console.WriteLine("4. Sort by Quantity");
		Console.Write("Enter your choice: ");
		string? sortChoice = Console.ReadLine();

		Comparison<Book>? comparison = sortChoice switch
		{
			"1" => (b1, b2) => string.Compare(b1.Title, b2.Title),
			"2" => (b1, b2) => string.Compare(b1.Author, b2.Author),
			"3" => (b1, b2) => b1.Price.CompareTo(b2.Price),
			"4" => (b1, b2) => b1.Quantity.CompareTo(b2.Quantity),
			_ => null
		};

		if (comparison == null)
		{
			Console.WriteLine("Invalid sort option.");
			return;
		}

		List<Book> sortedBooks = await _inventory.SortBooksAsync(comparison);
		Console.WriteLine("Sorted Books:");
		Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10} {6,10}",
			"ID", "Title", "Author", "ISBN", "Price", "Quantity", "Available");
		foreach (var b in sortedBooks)
		{
			Console.WriteLine(b.ToString());
		}
	}

	// ======= Các chức năng Import/Export =======

	private async Task ExportToJsonMenuAsync()
	{
		Console.WriteLine("========= Export to JSON =========");
		Console.Write("Enter file path to export JSON (e.g., books.json): ");
		string? filePath = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(filePath))
		{
			Console.WriteLine("Invalid file path.");
			return;
		}
		await _inventory.ExportToJsonAsync(filePath);
		Console.WriteLine("Books exported to JSON successfully.");
	}

	private async Task ImportFromJsonMenuAsync()
	{
		Console.WriteLine("========= Import from JSON =========");
		Console.Write("Enter file path to import JSON (e.g., books.json): ");
		string? filePath = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(filePath))
		{
			Console.WriteLine("Invalid file path.");
			return;
		}
		await _inventory.ImportFromJsonAsync(filePath);
		Console.WriteLine("Books imported from JSON successfully (only new books were added).");
	}

	private async Task ExportToExcelMenuAsync()
	{
		Console.WriteLine("========= Export to Excel =========");
		Console.Write("Enter file path to export Excel (e.g., books.xlsx): ");
		string? filePath = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(filePath))
		{
			Console.WriteLine("Invalid file path.");
			return;
		}
		await _inventory.ExportToExcelAsync(filePath);
		Console.WriteLine("Books exported to Excel successfully.");
	}

	private async Task ImportFromExcelMenuAsync()
	{
		Console.WriteLine("========= Import from Excel =========");
		Console.Write("Enter file path to import Excel (e.g., books.xlsx): ");
		string? filePath = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(filePath))
		{
			Console.WriteLine("Invalid file path.");
			return;
		}
		await _inventory.ImportFromExcelAsync(filePath);
		Console.WriteLine("Books imported from Excel successfully (only new books were added).");
	}
}

/*
 * using System;
using System.Collections.Generic;
using System.Linq;

using Test_Final.HelperInput;  // Giả sử InputHelper được đặt ở đây.
using Test_Final.Models;
using Test_Final.Services;

public class Program
{
    private readonly IBookInventoryService _inventory;

    public Program(IBookInventoryService inventory)
    {
        _inventory = inventory;
    }

    public static void Main(string[] args)
    {
        // Khởi tạo BookInventoryService và Program
        var inventory = new BookInventoryService();
        var program = new Program(inventory);

        // Chạy ứng dụng
        program.Run();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            try
            {
                Console.WriteLine("\n========== Bookstore Inventory ==========");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Display Books");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. Update Book");
                Console.WriteLine("6. Sort Books");
                Console.WriteLine("7. Export to JSON");
                Console.WriteLine("8. Import from JSON");
                Console.WriteLine("9. Export to Excel");
                Console.WriteLine("10. Import from Excel");
                Console.WriteLine("11. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookMenu();
                        break;

                    case "2":
                        RemoveBookMenu();
                        break;

                    case "3":
                        DisplayBooksMenu();
                        break;

                    case "4":
                        SearchBookMenu();
                        break;

                    case "5":
                        UpdateBookMenu();
                        break;

                    case "6":
                        SortBooksMenu();
                        break;

                    case "7":
                        ExportToJsonMenu();
                        break;

                    case "8":
                        ImportFromJsonMenu();
                        break;

                    case "9":
                        ExportToExcelMenu();
                        break;

                    case "10":
                        ImportFromExcelMenu();
                        break;

                    case "11":
                        exit = true;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    private void AddBookMenu()
    {
        Console.WriteLine("========= Add Book =========");
        int id = InputHelper.ReadInt("Enter book id: ");
        string isbn = InputHelper.ReadString("Enter book ISBN: ", true);
        string title = InputHelper.ReadString("Enter book title: ", true);
        string author = InputHelper.ReadString("Enter book author: ", false);
        decimal price = InputHelper.ReadDecimal("Enter book price: ");
        int quantity = InputHelper.ReadInt("Enter book quantity: ", allowZero: true);

        Book book = new Book(id, isbn, title, author, price, quantity);

        try
        {
            _inventory.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error adding book: " + ex.Message);
        }
    }

    private void RemoveBookMenu()
    {
        Console.WriteLine("========= Remove Book =========");
        int id = InputHelper.ReadInt("Enter book id: ");
        var book = _inventory.GetBook(id);
        if (book != null)
        {
            _inventory.RemoveBook(book);
            Console.WriteLine("Book removed successfully!");
        }
        else
        {
            Console.WriteLine("Book with ID {0} not found.", id);
        }
    }

    private void DisplayBooksMenu()
    {
        Console.WriteLine("========= Display Books =========");
        _inventory.DisplayBooks();
    }

    private void SearchBookMenu()
    {
        Console.WriteLine("========= Search Book =========");
        Console.Write("Enter search keyword: ");
        string keyword = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Keyword cannot be empty.");
            return;
        }

        List<Book> results;
        try
        {
            results = _inventory.SearchBook(keyword);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return;
        }

        if (results.Any())
        {
            Console.WriteLine("Search Results:");
            Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10} {6,10}",
                "ID", "Title", "Author", "ISBN", "Price", "Quantity", "Available");
            foreach (var b in results)
            {
                Console.WriteLine(b.ToString());
            }
        }
        else
        {
            Console.WriteLine("No books found matching the keyword.");
        }
    }

    private void UpdateBookMenu()
    {
        Console.WriteLine("========= Update Book =========");
        int id = InputHelper.ReadInt("Enter book id: ");
        var book = _inventory.GetBook(id);
        if (book != null)
        {
            int quantity = InputHelper.ReadInt("Enter quantity to update: ");
            try
            {
                var result = _inventory.UpdateBook(book, quantity);
                if (result.HasValue)
                {
                    Console.WriteLine("Book updated successfully.");
                    Console.WriteLine("New quantity: " + result.Value.Item2);
                }
                else
                {
                    Console.WriteLine("Book with ID {0} not found.", id);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error updating book: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Book with ID {0} not found.", id);
        }
    }

    private void SortBooksMenu()
    {
        Console.WriteLine("========= Sort Books =========");
        Console.WriteLine("1. Sort by Title");
        Console.WriteLine("2. Sort by Author");
        Console.WriteLine("3. Sort by Price");
        Console.WriteLine("4. Sort by Quantity");
        Console.Write("Enter your choice: ");
        string sortChoice = Console.ReadLine();

        Comparison<Book> comparison = sortChoice switch
        {
            "1" => (b1, b2) => string.Compare(b1.Title, b2.Title),
            "2" => (b1, b2) => string.Compare(b1.Author, b2.Author),
            "3" => (b1, b2) => b1.Price.CompareTo(b2.Price),
            "4" => (b1, b2) => b1.Quantity.CompareTo(b2.Quantity),
            _ => null
        };

        if (comparison == null)
        {
            Console.WriteLine("Invalid sort option.");
            return;
        }

        List<Book> sortedBooks = _inventory.SortBooks(comparison);
        Console.WriteLine("Sorted Books:");
        Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10} {6,10}",
            "ID", "Title", "Author", "ISBN", "Price", "Quantity", "Available");
        foreach (var b in sortedBooks)
        {
            Console.WriteLine(b.ToString());
        }
    }

    // ======= Các chức năng Import/Export =======

    private void ExportToJsonMenu()
    {
        Console.WriteLine("========= Export to JSON =========");
        Console.Write("Enter file path to export JSON (e.g., books.json): ");
        string filePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("Invalid file path.");
            return;
        }
        _inventory.ExportToJson(filePath);
        Console.WriteLine("Books exported to JSON successfully.");
    }

    private void ImportFromJsonMenu()
    {
        Console.WriteLine("========= Import from JSON =========");
        Console.Write("Enter file path to import JSON (e.g., books.json): ");
        string filePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("Invalid file path.");
            return;
        }
        _inventory.ImportFromJson(filePath);
        Console.WriteLine("Books imported from JSON successfully (only new books were added).");
    }

    private void ExportToExcelMenu()
    {
        Console.WriteLine("========= Export to Excel =========");
        Console.Write("Enter file path to export Excel (e.g., books.xlsx): ");
        string filePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("Invalid file path.");
            return;
        }
        _inventory.ExportToExcel(filePath);
        Console.WriteLine("Books exported to Excel successfully.");
    }

    private void ImportFromExcelMenu()
    {
        Console.WriteLine("========= Import from Excel =========");
        Console.Write("Enter file path to import Excel (e.g., books.xlsx): ");
        string filePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("Invalid file path.");
            return;
        }
        _inventory.ImportFromExcel(filePath);
        Console.WriteLine("Books imported from Excel successfully (only new books were added).");
    }
}
 */