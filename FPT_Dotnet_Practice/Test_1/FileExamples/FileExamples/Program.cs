using System;
using System.IO;

namespace FileExamples
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			// part 1 : class File
			fileClass1();
		}

		public static void fileClass1()
		{
			string filePath = @"D:\A_practice\input1.txt";
			string filePath2 = @"D:\A_practice\input2.txt";
			string filePath3 = @"D:\A_practice\another.txt";
			//case 1:  create file
			File.Create(filePath).Close();
			Console.WriteLine("File input1.txt created");

			//case 2:  check file exists
			//bool isExist = File.Exists(filePath);
			//if (isExist)
			//{
			//	File.Copy(filePath, filePath2);
			//	Console.WriteLine("Copied input1.txt to input2.txt");
			//}
			//else
			//{
			//	Console.WriteLine("File not found!!!");
			//}

			//case 3: rename file
			//if (File.Exists(filePath2))
			//{
			//	File.Move(filePath2, filePath3);
			//	Console.WriteLine("Rename input2.txt to another.txt");
			//}
			//else
			//{
			//	Console.WriteLine("File not found!!!");
			//}

			//case 4: delete file
			//if (File.Exists(filePath3))
			//{
			//	File.Delete(filePath3);
			//	Console.WriteLine("Delete another.txt");
			//}
			//else
			//{
			//	Console.WriteLine("File not found!!!");
			//}

			Console.ReadKey();
		}
	}
}