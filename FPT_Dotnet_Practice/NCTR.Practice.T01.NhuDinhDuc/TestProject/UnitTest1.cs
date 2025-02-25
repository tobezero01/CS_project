using Microsoft.Extensions.Logging.Abstractions;
using NCTR.Practice.T01.Problem2.Models;
using NCTR.Practice.T01.Problem2.Services;

namespace TestProject
{
	[TestFixture]
	public class Tests
	{
		private ProductManagement _productManagement;

		[SetUp]
		public void Setup()
		{
			_productManagement = new ProductManagement(NullLogger<ProductManagement>.Instance);
		}

		/// <summary>
		/// Adds the product successfull.
		/// </summary>
		[Test]
		public async Task AddProduct_Successfull()
		{
			var product = new Product(1, "Sinh vat", "PC12345", "sach hay", 13344, 12, "Other");
			await _productManagement.Add(product);
			var res = _productManagement.Get(product.Id);
			Assert.IsNotNull(res);
			Assert.AreEqual(1, res.Id);
		}

		/// <summary>
		/// Searches the book should return matching books.
		/// </summary>
		[Test]
		public async Task SearchBook_ShouldReturnMatchingBooks()
		{
			var product = new Product(1, "Sinh vat", "PC12345", "sach hay", 13344, 12, "Other");
			var product2 = new Product(2, "Sinh vat 1", "PC12445", "sach hay", 13344, 12, "Other");
			var product3 = new Product(3, "Khoa hoc", "PC12355", "sach hay", 13344, 12, "Other");
			await _productManagement.Add(product);
			await _productManagement.Add(product2);
			await _productManagement.Add(product3);

			var results = await _productManagement.Search("sinh vat");
			Assert.AreEqual(2, results.Count);
			Assert.IsTrue(results.All(b => b.Name.Contains("Alice")));
		}

		/// <summary>
		/// Searches the book asynchronous should return null.
		/// </summary>
		[Test]
		public async Task SearchBookAsync_ShouldReturnNull()
		{
			var product = new Product(1, "Sinh vat", "PC12345", "sach hay", 13344, 12, "Other");
			var product2 = new Product(2, "Sinh vat 1", "PC12445", "sach hay", 13344, 12, "Other");
			var product3 = new Product(3, "Khoa hoc", "PC12355", "sach hay", 13344, 12, "Other");
			await _productManagement.Add(product);
			await _productManagement.Add(product2);
			await _productManagement.Add(product3);

			var results = await _productManagement.Search("ducnhu");
			Assert.AreEqual(0, results.Count);
		}
	}
}