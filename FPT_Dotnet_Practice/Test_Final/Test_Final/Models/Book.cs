using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Final.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string ISBN { get; set; }     // Required.
		public string Title { get; set; }    // Required.
		public string Author { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Book"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="isbn">The isbn.</param>
		/// <param name="title">The title.</param>
		/// <param name="author">The author.</param>
		/// <param name="price">The price.</param>
		/// <param name="quantity">The quantity.</param>
		public Book(int id, string isbn, string title, string author, decimal price, int quantity)
		{
			Id = id;
			ISBN = isbn;
			Title = title;
			Author = author;
			Price = price;
			Quantity = quantity;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Book"/> class.
		/// </summary>
		public Book()
		{
		}

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			string available = Quantity > 0 ? "Available" : "Unavainable";
			return string.Format("{0,-5} {1,-30} {2,-20} {3,-15} {4,10:C} {5,10} {6,10}",
								 Id, Title, Author, ISBN, Price, Quantity, available);
		}
	}
}