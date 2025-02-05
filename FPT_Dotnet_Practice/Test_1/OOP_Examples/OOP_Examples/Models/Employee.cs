using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_Examples.Models
{
	public class Employee
	{
		public int id { get; set; }
		public string name { get; set; }
		public string _email { get; set; }

		public string Email
		{
			get { return _email; }
			set
			{
				if (value.Contains("@"))
				{
					_email = value;
				}
				else
				{
					throw new ArgumentException("Invalid Email!!!");
				}
			}
		}

		public DateTime DateOfBirth { get; set; }

		public int Age
		{ get { return DateTime.Now.Year - DateOfBirth.Year; } }

		public Employee()
		{ }

		public Employee(int id, string name, string email, DateTime dateOfBirth)
		{
			this.id = id;
			this.name = name;
			Email = email;
			DateOfBirth = dateOfBirth;
		}
	}
}