using Microsoft.Extensions.Logging.Abstractions;
using Test_Final.Models;
using Test_Final.Services;

namespace TestProject
{
	[TestFixture]
	public class Tests
	{
		private BookInventoryService _service;

		[SetUp]
		public void Setup()
		{
			// Sử dụng NullLogger để không cần quan tâm đến log
			_service = new BookInventoryService(NullLogger<BookInventoryService>.Instance);
		}

		[Test]
		public async Task AddBookAsync_ShouldAddBook()
		{
			var book = new Book(1, "ISBN001", "Title1", "Author1", 10.0m, 5);
			await _service.AddBookAsync(book);
			var result = await _service.GetBookAsync(1);
			Assert.IsNotNull(result);
			Assert.AreEqual("ISBN001", result.ISBN);
		}

		[Test]
		public void AddBookAsync_DuplicateISBN_ShouldThrowException()
		{
			var book1 = new Book(1, "ISBN002", "Title2", "Author2", 20.0m, 3);
			var book2 = new Book(2, "ISBN002", "Title3", "Author3", 15.0m, 2);
			Assert.DoesNotThrowAsync(async () => await _service.AddBookAsync(book1));
			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _service.AddBookAsync(book2));
			StringAssert.Contains("A book with the same ISBN already exists", ex.Message);
		}

		[Test]
		public async Task RemoveBookAsync_ShouldRemoveBook()
		{
			var book = new Book(1, "ISBN003", "Title3", "Author3", 12.0m, 7);
			await _service.AddBookAsync(book);
			await _service.RemoveBookAsync(book);
			var result = await _service.GetBookAsync(1);
			Assert.IsNull(result);
		}

		[Test]
		public async Task GetBookAsync_NotFound_ShouldReturnNull()
		{
			var result = await _service.GetBookAsync(999);
			Assert.IsNull(result);
		}

		[Test]
		public async Task UpdateBookAsync_ShouldUpdateQuantity()
		{
			var book = new Book(1, "ISBN004", "Title4", "Author4", 30.0m, 10);
			await _service.AddBookAsync(book);
			var updateResult = await _service.UpdateBookAsync(book, 15);
			Assert.IsNotNull(updateResult);
			Assert.AreEqual(15, updateResult.Value.Item2);
			var updatedBook = await _service.GetBookAsync(1);
			Assert.AreEqual(15, updatedBook.Quantity);
		}

		[Test]
		public async Task SearchBookAsync_ShouldReturnMatchingBooks()
		{
			var book1 = new Book(1, "ISBN005", "C# Programming", "Alice", 25.0m, 5);
			var book2 = new Book(2, "ISBN006", "Java Programming", "Bob", 30.0m, 3);
			var book3 = new Book(3, "ISBN007", "Python Programming", "Alice", 20.0m, 4);
			await _service.AddBookAsync(book1);
			await _service.AddBookAsync(book2);
			await _service.AddBookAsync(book3);

			var results = await _service.SearchBookAsync("Alice");
			Assert.AreEqual(2, results.Count);
			Assert.IsTrue(results.All(b => b.Author.Contains("Alice")));
		}

		[Test]
		public async Task SortBooksAsync_ShouldSortByTitle()
		{
			var book1 = new Book(1, "ISBN008", "Zeta", "Author1", 10.0m, 1);
			var book2 = new Book(2, "ISBN009", "Alpha", "Author2", 20.0m, 2);
			var book3 = new Book(3, "ISBN010", "Beta", "Author3", 30.0m, 3);
			await _service.AddBookAsync(book1);
			await _service.AddBookAsync(book2);
			await _service.AddBookAsync(book3);

			var sorted = await _service.SortBooksAsync((b1, b2) => string.Compare(b1.Title, b2.Title));
			Assert.AreEqual("Alpha", sorted.First().Title);
		}

		[Test]
		public async Task ExportToJsonAsync_And_ImportFromJsonAsync_ShouldWork()
		{
			// Arrange: tạo instance service và thêm một số sách.
			var book1 = new Book(1, "ISBN011", "Book1", "Author1", 10.0m, 1);
			var book2 = new Book(2, "ISBN012", "Book2", "Author2", 20.0m, 2);
			await _service.AddBookAsync(book1);
			await _service.AddBookAsync(book2);

			string tempFile = Path.Combine(Path.GetTempPath(), "TestBooks.json");

			// Act: xuất dữ liệu ra file JSON.
			await _service.ExportToJsonAsync(tempFile);

			// Tạo một instance mới để kiểm tra import (không ghi đè)
			var importService = new BookInventoryService(NullLogger<BookInventoryService>.Instance);
			await importService.ImportFromJsonAsync(tempFile);

			// Assert: kiểm tra số lượng sách được import.
			var allBooks = await importService.GetAllBooksAsync();
			Assert.AreEqual(2, allBooks.Count);

			// Cleanup
			if (File.Exists(tempFile))
				File.Delete(tempFile);
		}

		[Test]
		public async Task ExportToExcelAsync_And_ImportFromExcelAsync_ShouldWork()
		{
			// Arrange: thêm một số sách.
			var book1 = new Book(1, "ISBN013", "Book3", "Author3", 15.0m, 3);
			var book2 = new Book(2, "ISBN014", "Book4", "Author4", 25.0m, 4);
			await _service.AddBookAsync(book1);
			await _service.AddBookAsync(book2);

			string tempFile = Path.Combine(Path.GetTempPath(), "TestBooks.xlsx");

			// Act: xuất dữ liệu ra file Excel.
			await _service.ExportToExcelAsync(tempFile);

			// Tạo một instance mới để kiểm tra import.
			var importService = new BookInventoryService(NullLogger<BookInventoryService>.Instance);
			await importService.ImportFromExcelAsync(tempFile);

			// Assert: kiểm tra số lượng sách được import.
			var allBooks = await importService.GetAllBooksAsync();
			Assert.AreEqual(2, allBooks.Count);

			// Cleanup
			if (File.Exists(tempFile))
				File.Delete(tempFile);
		}
	}
}

/*
 * using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using Test_Final.Models;
using Test_Final.Services;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        private BookInventoryService _service;

        [SetUp]
        public void Setup()
        {
            // Khởi tạo BookInventoryService
            _service = new BookInventoryService();
        }

        [Test]
        public void AddBook_ShouldAddBook()
        {
            var book = new Book(1, "ISBN001", "Title1", "Author1", 10.0m, 5);
            _service.AddBook(book);
            var result = _service.GetBook(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("ISBN001", result.ISBN);
        }

        [Test]
        public void AddBook_DuplicateISBN_ShouldThrowException()
        {
            var book1 = new Book(1, "ISBN002", "Title2", "Author2", 20.0m, 3);
            var book2 = new Book(2, "ISBN002", "Title3", "Author3", 15.0m, 2);
            Assert.DoesNotThrow(() => _service.AddBook(book1));
            var ex = Assert.Throws<ArgumentException>(() => _service.AddBook(book2));
            StringAssert.Contains("A book with the same ISBN already exists", ex.Message);
        }

        [Test]
        public void RemoveBook_ShouldRemoveBook()
        {
            var book = new Book(1, "ISBN003", "Title3", "Author3", 12.0m, 7);
            _service.AddBook(book);
            _service.RemoveBook(book);
            var result = _service.GetBook(1);
            Assert.IsNull(result);
        }

        [Test]
        public void GetBook_NotFound_ShouldReturnNull()
        {
            var result = _service.GetBook(999);
            Assert.IsNull(result);
        }

        [Test]
        public void UpdateBook_ShouldUpdateQuantity()
        {
            var book = new Book(1, "ISBN004", "Title4", "Author4", 30.0m, 10);
            _service.AddBook(book);
            var updateResult = _service.UpdateBook(book, 15);
            Assert.IsNotNull(updateResult);
            Assert.AreEqual(15, updateResult.Value.Item2);
            var updatedBook = _service.GetBook(1);
            Assert.AreEqual(15, updatedBook.Quantity);
        }

        [Test]
        public void SearchBook_ShouldReturnMatchingBooks()
        {
            var book1 = new Book(1, "ISBN005", "C# Programming", "Alice", 25.0m, 5);
            var book2 = new Book(2, "ISBN006", "Java Programming", "Bob", 30.0m, 3);
            var book3 = new Book(3, "ISBN007", "Python Programming", "Alice", 20.0m, 4);
            _service.AddBook(book1);
            _service.AddBook(book2);
            _service.AddBook(book3);

            var results = _service.SearchBook("Alice");
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(b => b.Author.Contains("Alice")));
        }

        [Test]
        public void SortBooks_ShouldSortByTitle()
        {
            var book1 = new Book(1, "ISBN008", "Zeta", "Author1", 10.0m, 1);
            var book2 = new Book(2, "ISBN009", "Alpha", "Author2", 20.0m, 2);
            var book3 = new Book(3, "ISBN010", "Beta", "Author3", 30.0m, 3);
            _service.AddBook(book1);
            _service.AddBook(book2);
            _service.AddBook(book3);

            var sorted = _service.SortBooks((b1, b2) => string.Compare(b1.Title, b2.Title));
            Assert.AreEqual("Alpha", sorted.First().Title);
        }

        [Test]
        public void ExportToJson_And_ImportFromJson_ShouldWork()
        {
            // Arrange: tạo instance service và thêm một số sách.
            var book1 = new Book(1, "ISBN011", "Book1", "Author1", 10.0m, 1);
            var book2 = new Book(2, "ISBN012", "Book2", "Author2", 20.0m, 2);
            _service.AddBook(book1);
            _service.AddBook(book2);

            string tempFile = Path.Combine(Path.GetTempPath(), "TestBooks.json");

            // Act: xuất dữ liệu ra file JSON.
            _service.ExportToJson(tempFile);

            // Tạo một instance mới để kiểm tra import (không ghi đè)
            var importService = new BookInventoryService();
            importService.ImportFromJson(tempFile);

            // Assert: kiểm tra số lượng sách được import.
            var allBooks = importService.GetAllBooks();
            Assert.AreEqual(2, allBooks.Count);

            // Cleanup
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }

        [Test]
        public void ExportToExcel_And_ImportFromExcel_ShouldWork()
        {
            // Arrange: thêm một số sách.
            var book1 = new Book(1, "ISBN013", "Book3", "Author3", 15.0m, 3);
            var book2 = new Book(2, "ISBN014", "Book4", "Author4", 25.0m, 4);
            _service.AddBook(book1);
            _service.AddBook(book2);

            string tempFile = Path.Combine(Path.GetTempPath(), "TestBooks.xlsx");

            // Act: xuất dữ liệu ra file Excel.
            _service.ExportToExcel(tempFile);

            // Tạo một instance mới để kiểm tra import.
            var importService = new BookInventoryService();
            importService.ImportFromExcel(tempFile);

            // Assert: kiểm tra số lượng sách được import.
            var allBooks = importService.GetAllBooks();
            Assert.AreEqual(2, allBooks.Count);

            // Cleanup
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }
}
 */