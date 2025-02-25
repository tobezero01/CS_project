using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NCTR.Practice.T01.Problem2.Exception;
using NCTR.Practice.T01.Problem2.Models;
using NCTR.Practice.T01.Problem2.Services;
using System.Text.RegularExpressions;

public class Program
{
	private readonly IProductManagement _productManagement;
	private readonly ILogger<Program> _logger;

	public Program(IProductManagement productManagement, ILogger<Program> logger)
	{
		_productManagement = productManagement;
		_logger = logger;
	}

	public static async Task Main(string[] args)
	{
		// Cấu hình Dependency Injection
		var serviceCollection = new ServiceCollection();
		ConfigureServices(serviceCollection);
		var serviceProvider = serviceCollection.BuildServiceProvider();

		// Lấy đối tượng Program đã được DI và chạy ứng dụng.
		var program = serviceProvider.GetRequiredService<Program>();
		await program.runMenu();
	}

	private static void ConfigureServices(ServiceCollection services)
	{
		services.AddLogging(builder =>
		{
			builder.AddConsole()
				   .AddDebug()
				   .SetMinimumLevel(LogLevel.Information);
		});
		services.AddSingleton<IProductManagement, ProductManagement>();

		services.AddSingleton<Program>();
	}

	/// <summary>
	/// Runs the menu.
	/// </summary>
	public async Task runMenu()
	{
		bool exit = false;
		while (!exit)
		{
			try
			{
				Console.WriteLine("\n========== Product Management ==========");
				Console.WriteLine("1. Add product");
				Console.WriteLine("2. Get all product");
				Console.WriteLine("3. Remove product");
				Console.WriteLine("4. Search product");
				Console.WriteLine("5. Search Advanced product");
				Console.WriteLine("6. Exit");
				Console.Write("Enter your choice: ");
				string? choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						await AddProduct();
						break;

					case "2":
						await GetAll();
						break;

					case "3":
						await RemoveProduct();
						break;

					case "4":
						await SearchByName();
						break;

					case "5":
						await AdvancedSearch();
						break;

					case "6":
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

	/// <summary>
	/// Removes the product.
	/// </summary>
	private async Task RemoveProduct()
	{
		Console.WriteLine("========= Remove product =========");
		string code = ReadCode("Enter code : ");
		await _productManagement.Remove(code);
	}

	/// <summary>
	/// Adds the product.
	/// </summary>
	private async Task AddProduct()
	{
		Console.WriteLine("========= Add Product =========");
		int id = ReadInt("Enter ID :");
		string name = ReadString("Enter name product :");
		string code = ReadCode("Enter code :");
		string description = ReadString("Enter Description : ");
		decimal price = ReadDecimal("Enter decimal : ");
		decimal discount = ReadDecimal("Enter discount : ");
		string category = ReadCategory("Enter category : ");

		Product product = new Product(id, name, code, description, price, discount, category);

		await _productManagement.Add(product);
	}

	/// <summary>
	/// Gets all.
	/// </summary>
	private async Task GetAll()
	{
		Console.WriteLine("========= Display product =========");
		await _productManagement.GetAll();
	}

	/// <summary>
	/// Advanceds the search.
	/// </summary>
	private async Task AdvancedSearch()
	{
	}

	/// <summary>
	/// Searches the name of the by.
	/// </summary>
	private async Task SearchByName()
	{
		Console.WriteLine("========= Search Product =========");
		string? keyword = ReadString("Enter name for searching : ");

		if (string.IsNullOrWhiteSpace(keyword))
		{
			Console.WriteLine("Name cannot be empty.");
			await Task.CompletedTask;
		}
		List<Product> results;
		try
		{
			results = await _productManagement.Search(keyword);
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine("Error: " + ex.Message);
			return;
		}

		if (results.Any())
		{
			Console.WriteLine("{0,-5} {1,-30} {2,-10} {3,-35} {4,-10} {5,-10} {6,-10}",
			"Id", "Name", "Code", "Description", "Price", "Discount", "Category");
			foreach (var product in results)
			{
				Console.WriteLine(product.ToString());
			}
		}
		else
		{
			Console.WriteLine("No product found matching the keyword.");
		}
	}

	/// <summary>
	/// Reads the int.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <returns></returns>
	public static int ReadInt(string message)
	{
		int value;
		while (true)
		{
			Console.Write(message);
			string? input = Console.ReadLine();
			if (int.TryParse(input, out value))
			{
				if (value < 0)
				{
					Console.WriteLine("Value cannot be negative.");
				}
				else
				{
					return value;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Try else number.");
			}
		}
	}

	/// <summary>
	/// Reads the string.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <returns>valid string</returns>
	public static string ReadString(string message)
	{
		while (true)
		{
			Console.Write(message);
			string? input = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(input))
			{
				Console.WriteLine("Please enter again.");
			}
			else
			{
				return input ?? string.Empty;
			}
		}
	}

	/// <summary>
	/// Reads the decimal.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <returns>Valid decimal</returns>
	public static decimal ReadDecimal(string message)
	{
		decimal value;
		while (true)
		{
			Console.Write(message);
			string? input = Console.ReadLine();
			if (decimal.TryParse(input, out value))
			{
				if (value < 0)
				{
					Console.WriteLine("Value cannot be negative. Again");
				}
				else
				{
					return value;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Try else number.");
			}
		}
	}

	/// <summary>
	/// Reads the category.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <returns>Valid category</returns>
	/// <exception cref="NCTR.Practice.T01.Problem2.Exception.InvalidCategoryException">Category value is not correct</exception>
	private string ReadCategory(string message)
	{
		while (true)
		{
			Console.Write(message);
			string? input = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(input))
			{
				Console.WriteLine("Please enter again.");
			}
			else if (!input.Equals("Fashion") && !input.Equals("Tech")
				&& !input.Equals("F&B") && !input.Equals("Other"))
			{
				throw new InvalidCategoryException("Category value is not correct");
			}
			else
			{
				return input ?? string.Empty;
			}
		}
	}

	/// <summary>
	/// Reads the code.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <returns>Valid code</returns>
	/// <exception cref="NCTR.Practice.T01.Problem2.Exception.InvalidCodeException">Code value is not correct</exception>
	private string ReadCode(string message)
	{
		string pattern = @"[0-9a-zA-Z]";
		while (true)
		{
			Console.Write(message);
			string? input = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(input))
			{
				Console.WriteLine("Please enter again.");
			}
			else if (!input.StartsWith("PC") && input.Length != 7 &&
				!Regex.IsMatch(input, pattern)
				)
			{
				throw new InvalidCodeException("Code value is not correct");
			}
			else
			{
				return input ?? string.Empty;
			}
		}
	}
}