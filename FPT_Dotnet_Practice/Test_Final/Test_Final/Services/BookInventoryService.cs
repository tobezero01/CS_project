using Microsoft.Extensions.Logging;
using OfficeOpenXml;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test_Final.Models;

namespace Test_Final.Services
{
	public class BookInventoryService : IBookInventoryService
	{
		private readonly List<Book> books = new List<Book>();
		private readonly ILogger<BookInventoryService> _logger;

		public BookInventoryService(ILogger<BookInventoryService> logger)
		{
			_logger = logger;
		}

		public Task AddBookAsync(Book book)
		{
			if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null");
			if (string.IsNullOrWhiteSpace(book.ISBN))
			{
				throw new ArgumentException("Book ISBN is required.", nameof(book.ISBN));
			}
			if (books.Any(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase)))
			{
				throw new ArgumentException("A book with the same ISBN already exists.", nameof(book));
			}

			books.Add(book);
			_logger.LogInformation("Book with ISBN {ISBN} added.", book.ISBN);
			return Task.CompletedTask;
		}

		public Task DisplayBooksAsync()
		{
			if (!books.Any())
			{
				Console.WriteLine("No books in inventory.");
				return Task.CompletedTask;
			}
			Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10} {6,10}",
				  "ID", "Title", "Author", "ISBN", "Price", "Quantity", "Available");
			foreach (var book in books)
			{
				Console.WriteLine(book.ToString());
			}
			return Task.CompletedTask;
		}

		public Task<Book?> GetBookAsync(int id)
		{
			var book = books.FirstOrDefault(b => b.Id == id);
			return Task.FromResult(book);
		}

		public Task RemoveBookAsync(Book book)
		{
			if (book == null)
				throw new ArgumentNullException(nameof(book), "Book cannot be null.");

			if (!books.Remove(book))
				throw new ArgumentException("Book not found in inventory.", nameof(book));

			_logger.LogInformation("Book with ISBN {ISBN} removed.", book.ISBN);
			return Task.CompletedTask;
		}

		public Task<List<Book>> SearchBookAsync(string keyword)
		{
			if (string.IsNullOrWhiteSpace(keyword))
				throw new ArgumentException("Keyword cannot be empty.", nameof(keyword));

			keyword = keyword.ToLower();

			var result = books.Where(b =>
				(!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(keyword)) ||
				(!string.IsNullOrEmpty(b.Author) && b.Author.ToLower().Contains(keyword))
			).ToList();

			return Task.FromResult(result);
		}

		public Task<List<Book>> SortBooksAsync(Comparison<Book> comparison)
		{
			if (comparison == null)
				throw new ArgumentNullException(nameof(comparison), "Comparison delegate cannot be null.");

			List<Book> sortedBooks = new List<Book>(books);
			sortedBooks.Sort(comparison);
			return Task.FromResult(sortedBooks);
		}

		public Task<(Book, int)?> UpdateBookAsync(Book book, int quantity)
		{
			if (book == null)
				throw new ArgumentNullException(nameof(book), "Book cannot be null.");

			if (quantity < 0)
				throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");

			var foundBook = books.FirstOrDefault(b => b.Id == book.Id);

			if (foundBook != null)
			{
				foundBook.Quantity = quantity;
				_logger.LogInformation("Book with ISBN {ISBN} updated with new quantity {Quantity}.", foundBook.ISBN, quantity);
				return Task.FromResult<(Book, int)?>((foundBook, quantity));
			}

			return Task.FromResult<(Book, int)?>(null);
		}

		/// <summary>
		/// Exports all books in the inventory to a JSON file.
		/// </summary>
		/// <param name="filePath">The file path where the JSON file will be saved.</param>
		public async Task ExportToJsonAsync(string filePath)
		{
			try
			{
				string json = JsonConvert.SerializeObject(books, Formatting.Indented);
				await File.WriteAllTextAsync(filePath, json);
				_logger.LogInformation("Books exported to JSON successfully.");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error exporting books to JSON.");
				throw;
			}
		}

		/// <summary>
		/// Imports books from a JSON file and adds only those that do not already exist (based on ISBN).
		/// </summary>
		/// <param name="filePath">The file path from where to import the JSON file.</param>
		public async Task ImportFromJsonAsync(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
				{
					_logger.LogWarning("JSON file not found: {FilePath}", filePath);
					return;
				}

				string json = await File.ReadAllTextAsync(filePath);
				List<Book>? importedBooks = JsonConvert.DeserializeObject<List<Book>>(json);
				if (importedBooks == null)
				{
					_logger.LogWarning("No books imported from JSON.");
					return;
				}

				int countAdded = 0;
				foreach (var book in importedBooks)
				{
					// Kiểm tra dựa trên ISBN (không ghi đè)
					if (!books.Any(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase)))
					{
						books.Add(book);
						countAdded++;
						_logger.LogInformation("Book with ISBN {ISBN} imported.", book.ISBN);
					}
					else
					{
						_logger.LogInformation("Book with ISBN {ISBN} already exists. Skipping.", book.ISBN);
					}
				}
				_logger.LogInformation("Import from JSON completed. {Count} new book(s) added.", countAdded);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error importing books from JSON.");
				throw;
			}
		}

		/// <summary>
		/// Exports all books in the inventory to an Excel file.
		/// </summary>
		/// <param name="filePath">The file path where the Excel file will be saved.</param>
		public async Task ExportToExcelAsync(string filePath)
		{
			try
			{
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
				using (var package = new ExcelPackage())
				{
					var worksheet = package.Workbook.Worksheets.Add("Books");

					// Ghi tiêu đề cột.
					worksheet.Cells[1, 1].Value = "Id";
					worksheet.Cells[1, 2].Value = "ISBN";
					worksheet.Cells[1, 3].Value = "Title";
					worksheet.Cells[1, 4].Value = "Author";
					worksheet.Cells[1, 5].Value = "Price";
					worksheet.Cells[1, 6].Value = "Quantity";

					int row = 2;
					foreach (var book in books)
					{
						worksheet.Cells[row, 1].Value = book.Id;
						worksheet.Cells[row, 2].Value = book.ISBN;
						worksheet.Cells[row, 3].Value = book.Title;
						worksheet.Cells[row, 4].Value = book.Author;
						worksheet.Cells[row, 5].Value = book.Price;
						worksheet.Cells[row, 6].Value = book.Quantity;
						row++;
					}

					FileInfo fi = new FileInfo(filePath);
					await package.SaveAsAsync(fi);
				}
				_logger.LogInformation("Books exported to Excel successfully.");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error exporting books to Excel.");
				throw;
			}
		}

		public async Task<List<Book>> GetAllBooksAsync()
		{
			return await Task.FromResult(books);
		}

		/// <summary>
		/// Imports books from an Excel file and adds only those that do not already exist (based on ISBN).
		/// Assumes the first row contains headers: Id, ISBN, Title, Author, Price, Quantity.
		/// </summary>
		/// <param name="filePath">The file path from where to import the Excel file.</param>
		public async Task ImportFromExcelAsync(string filePath)
		{
			try
			{
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
				FileInfo fi = new FileInfo(filePath);
				if (!fi.Exists)
				{
					_logger.LogWarning("Excel file not found: {FilePath}", filePath);
					return;
				}

				int countAdded = 0;
				using (var package = new ExcelPackage(fi))
				{
					var worksheet = package.Workbook.Worksheets.FirstOrDefault();
					if (worksheet == null)
					{
						_logger.LogWarning("No worksheet found in Excel file.");
						return;
					}

					int rowCount = worksheet.Dimension.Rows;
					// Duyệt từ dòng 2 (vì dòng 1 chứa header)
					for (int row = 2; row <= rowCount; row++)
					{
						int id = Convert.ToInt32(worksheet.Cells[row, 1].Value ?? 0);
						string isbn = worksheet.Cells[row, 2].Value?.ToString() ?? "";
						string title = worksheet.Cells[row, 3].Value?.ToString() ?? "";
						string author = worksheet.Cells[row, 4].Value?.ToString() ?? "";
						decimal price = worksheet.Cells[row, 5].Value != null ? Convert.ToDecimal(worksheet.Cells[row, 5].Value) : 0;
						int quantity = worksheet.Cells[row, 6].Value != null ? Convert.ToInt32(worksheet.Cells[row, 6].Value) : 0;

						Book book = new Book(id, isbn, title, author, price, quantity);
						if (!books.Any(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase)))
						{
							books.Add(book);
							countAdded++;
							_logger.LogInformation("Book with ISBN {ISBN} imported from Excel.", book.ISBN);
						}
						else
						{
							_logger.LogInformation("Book with ISBN {ISBN} already exists. Skipping.", book.ISBN);
						}
					}
				}
				_logger.LogInformation("Import from Excel completed. {Count} new book(s) added.", countAdded);
				await Task.CompletedTask;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error importing books from Excel.");
				throw;
			}
		}
	}
}

/*
 * using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OfficeOpenXml;
using Test_Final.Models;

namespace Test_Final.Services
{
    public class BookInventoryService
    {
        private readonly List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null");
            if (string.IsNullOrWhiteSpace(book.ISBN))
                throw new ArgumentException("Book ISBN is required.", nameof(book.ISBN));
            if (books.Any(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("A book with the same ISBN already exists.", nameof(book));

            books.Add(book);
        }

        public void DisplayBooks()
        {
            if (!books.Any())
            {
                Console.WriteLine("No books in inventory.");
                return;
            }
            Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10} {6,10}",
                  "ID", "Title", "Author", "ISBN", "Price", "Quantity", "Available");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public Book? GetBook(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            if (!books.Remove(book))
                throw new ArgumentException("Book not found in inventory.", nameof(book));
        }

        public List<Book> SearchBook(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Keyword cannot be empty.", nameof(keyword));

            keyword = keyword.ToLower();
            return books.Where(b =>
                (!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(b.Author) && b.Author.ToLower().Contains(keyword))
            ).ToList();
        }

        public List<Book> SortBooks(Comparison<Book> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison), "Comparison delegate cannot be null.");

            List<Book> sortedBooks = new List<Book>(books);
            sortedBooks.Sort(comparison);
            return sortedBooks;
        }

        public (Book, int)? UpdateBook(Book book, int quantity)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");

            var foundBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (foundBook != null)
            {
                foundBook.Quantity = quantity;
                return (foundBook, quantity);
            }
            return null;
        }

        public void ExportToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void ImportFromJson(string filePath)
        {
            if (!File.Exists(filePath)) return;

            string json = File.ReadAllText(filePath);
            List<Book>? importedBooks = JsonConvert.DeserializeObject<List<Book>>(json);
            if (importedBooks == null) return;

            foreach (var book in importedBooks)
            {
                if (!books.Any(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase)))
                {
                    books.Add(book);
                }
            }
        }

        public void ExportToExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Books");
                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "ISBN";
                worksheet.Cells[1, 3].Value = "Title";
                worksheet.Cells[1, 4].Value = "Author";
                worksheet.Cells[1, 5].Value = "Price";
                worksheet.Cells[1, 6].Value = "Quantity";

                int row = 2;
                foreach (var book in books)
                {
                    worksheet.Cells[row, 1].Value = book.Id;
                    worksheet.Cells[row, 2].Value = book.ISBN;
                    worksheet.Cells[row, 3].Value = book.Title;
                    worksheet.Cells[row, 4].Value = book.Author;
                    worksheet.Cells[row, 5].Value = book.Price;
                    worksheet.Cells[row, 6].Value = book.Quantity;
                    row++;
                }

                FileInfo fi = new FileInfo(filePath);
                package.SaveAs(fi);
            }
        }

        public void ImportFromExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists) return;

            using (var package = new ExcelPackage(fi))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null) return;

                int rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++)
                {
                    int id = Convert.ToInt32(worksheet.Cells[row, 1].Value ?? 0);
                    string isbn = worksheet.Cells[row, 2].Value?.ToString() ?? "";
                    string title = worksheet.Cells[row, 3].Value?.ToString() ?? "";
                    string author = worksheet.Cells[row, 4].Value?.ToString() ?? "";
                    decimal price = worksheet.Cells[row, 5].Value != null ? Convert.ToDecimal(worksheet.Cells[row, 5].Value) : 0;
                    int quantity = worksheet.Cells[row, 6].Value != null ? Convert.ToInt32(worksheet.Cells[row, 6].Value) : 0;

                    if (!books.Any(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
                    {
                        books.Add(new Book { Id = id, ISBN = isbn, Title = title, Author = author, Price = price, Quantity = quantity });
                    }
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>(books);
        }
    }
}
 */