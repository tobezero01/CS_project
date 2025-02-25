using Microsoft.Extensions.Logging;
using NCTR.Practice.T01.Problem2.Exception;
using NCTR.Practice.T01.Problem2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace NCTR.Practice.T01.Problem2.Services
{
	public class ProductManagement : IProductManagement
	{
		private readonly List<Product> products = new List<Product>();
		private readonly ILogger<ProductManagement> _logger;

		public ProductManagement(ILogger<ProductManagement> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Adds the specified product.
		/// </summary>
		/// <param name="product">The product.</param>
		/// <returns></returns>
		/// <exception cref="NCTR.Practice.T01.Problem2.Exception.ProductNotFoundException">Product Not Found</exception>
		/// <exception cref="System.ArgumentException">A product with the same code already exists.</exception>
		public Task Add(Product product)
		{
			if (product == null) throw new ProductNotFoundException("Product Not Found");
			if (products.Any(b => b.Code.Equals(product.Code, StringComparison.OrdinalIgnoreCase)))
			{
				throw new ArgumentException("A product with the same code already exists.");
			}
			products.Add(product);
			_logger.LogInformation("Product with code {code} added.", product.Code);

			return Task.CompletedTask;
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>
		/// list product
		/// </returns>
		public Task GetAll()
		{
			if (!products.Any())
			{
				Console.WriteLine("No Product in lists.");
				return Task.CompletedTask;
			}
			Console.WriteLine("{0,-5} {1,-30} {2,-10} {3,-35} {4,-10} {5,-10} {6,-10}",
			"Id", "Name", "Code", "Description", "Price", "Discount", "Category");
			foreach (var product in products)
			{
				Console.WriteLine(product.ToString());
			}
			return Task.CompletedTask;
		}

		public Product? Get(int id)
		{
			return products.FirstOrDefault(p => p.Id == id);
		}

		/// <summary>
		/// Removes the specified code.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <returns></returns>
		/// <exception cref="NCTR.Practice.T01.Problem2.Exception.ProductNotFoundException">Product Not Found</exception>
		/// <exception cref="System.ArgumentException">Product not found in list.</exception>
		public Task Remove(string code)
		{
			Product? product = products.FirstOrDefault(p => p.Code.Equals(code));

			if (product == null) throw new ProductNotFoundException("Product Not Found");
			if (!products.Remove(product))
			{
				throw new ArgumentException("Product not found in list.");
			}
			_logger.LogInformation("Product with code {code} removed.", product.Code);

			return Task.CompletedTask;
		}

		/// <summary>
		/// Searches the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>
		/// list product search
		/// </returns>
		/// <exception cref="System.ArgumentException">Name cannot be empty. - name</exception>
		public Task<List<Product>> Search(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Name cannot be empty.", nameof(name));
			}
			name = name.Trim().ToLower();

			var result = products.Where(p =>
				(!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(name))

			).ToList();
			return Task.FromResult(result);
		}

		/// <summary>
		/// Searches the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="minPrice">The minimum price.</param>
		/// <param name="maxPrice">The maximum price.</param>
		/// <param name="pageNum">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>
		/// Search advanced
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Task<List<Product>> Search(string name, decimal? minPrice, decimal? maxPrice, int pageNum, int pageSize)
		{
			throw new NotImplementedException();
		}
	}
}