using System;

namespace Day2_ArraysBasic.Main_Arrays
{
	internal class main_array
	{
		private static void Main(string[] args)
		{
			int size = GetPositiveInt("Enter the size of array: ");

			Console.WriteLine($"Size of array: {size}");
			int[] numbers = new int[size];

			Console.WriteLine("Enter the elements of array:");
			for (int i = 0; i < size; i++)
			{
				numbers[i] = GetInt($"Enter the element at index {i}: ");
			}

			Console.WriteLine("Array:");
			Console.WriteLine(string.Join(" ", numbers));

			Console.ReadKey();
		}

		// Hàm phụ trợ nhập số nguyên, kiểm tra nhập hợp lệ.
		/// <summary>
		/// Gets the int.
		/// </summary>
		/// <param name="prompt">The prompt.</param>
		/// <returns>value</returns>
		private static int GetInt(string prompt)
		{
			int value;
			while (true)
			{
				Console.Write(prompt);
				if (int.TryParse(Console.ReadLine(), out value))
				{
					return value;
				}
				Console.WriteLine("Invalid input, please try again.");
			}
		}

		// Hàm phụ trợ nhập số nguyên dương.
		/// <summary>
		/// Gets the positive int.
		/// </summary>
		/// <param name="prompt">The prompt.</param>
		/// <returns></returns>
		private static int GetPositiveInt(string prompt)
		{
			int value;
			while (true)
			{
				value = GetInt(prompt);
				if (value > 0)
				{
					return value;
				}
				Console.WriteLine("Please enter a positive integer.");
			}
		}
	}
}