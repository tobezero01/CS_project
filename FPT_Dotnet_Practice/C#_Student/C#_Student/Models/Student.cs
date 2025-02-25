using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Student.Models
{
	[Serializable]
	public class Student
	{
		public Student()
		{
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public int Age
		{ get; set; }

		public Student(int id, string name, int age)
		{
			Id = id;
			Name = name;
			Age = age;
		}

		public override string ToString()
		{
			return $"ID: {Id}, Name: {Name}, Age: {Age}";
		}
	}
}