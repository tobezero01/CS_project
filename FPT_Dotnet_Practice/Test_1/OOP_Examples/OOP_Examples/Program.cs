using OOP_Examples.Models;
using System;

internal class Program
{
	public static void Main(String[] args)
	{
		Employee duc = new Employee();
		duc.id = 1;
		duc.name = "duc nhu";
		duc.Email = "ducnhu123@gmail.com";
		Console.WriteLine(duc.id);
		Console.WriteLine(duc.name);
		Console.WriteLine(duc.Email);
	}
}