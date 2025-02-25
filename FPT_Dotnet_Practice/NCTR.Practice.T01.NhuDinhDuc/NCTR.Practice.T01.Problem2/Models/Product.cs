using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTR.Practice.T01.Problem2.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }

		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public string Category { get; set; }

		public Product(int id, string name, string code, string description, decimal price, decimal discount, string category)
		{
			Id = id;
			Name = name;
			Code = code;
			Description = description;
			Price = price;
			Discount = discount;
			Category = category;
		}

		public Product()
		{
		}

		public override string ToString()
		{
			return string.Format("{0,-5} {1,-30} {2,-10} {3,-35} {4,-10} {5,-10} {6,-10}",
								 Id, Name, Code, Description, Price, Discount, Category);
		}
	}
}