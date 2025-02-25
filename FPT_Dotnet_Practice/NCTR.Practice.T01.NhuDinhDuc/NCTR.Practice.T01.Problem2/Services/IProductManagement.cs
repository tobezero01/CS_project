using NCTR.Practice.T01.Problem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTR.Practice.T01.Problem2.Services
{
	public interface IProductManagement
	{
		/// <summary>
		/// Adds the specified product.
		/// </summary>
		/// <param name="product">The product.</param>
		/// <returns></returns>
		Task Add(Product product);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>list product</returns>
		Task GetAll();

		/// <summary>
		/// Removes the specified code.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <returns></returns>
		Task Remove(string code);

		/// <summary>
		/// Searches the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>list product search</returns>
		Task<List<Product>> Search(string name);

		/// <summary>
		/// Searches the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="minPrice">The minimum price.</param>
		/// <param name="maxPrice">The maximum price.</param>
		/// <param name="pageNum">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Search advanced</returns>
		Task<List<Product>> Search(string name, decimal? minPrice, decimal? maxPrice, int pageNum, int pageSize);
	}
}