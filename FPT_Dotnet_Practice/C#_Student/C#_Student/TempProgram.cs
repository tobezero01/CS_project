using C__Student;
using System;

namespace StudentManagementApp
{
	internal class TempProgram
	{
		private static StudentManagement management = new StudentManagement();

		private static void Main(string[] args)
		{
			bool exit = false;
			while (!exit)
			{
				Console.WriteLine("\n==== Student Management Menu ====");
				Console.WriteLine("1. Add Student");
				Console.WriteLine("2. Remove Student");
				Console.WriteLine("3. Update Student");
				Console.WriteLine("4. List Students");
				Console.WriteLine("5. Import Students from JSON");
				Console.WriteLine("6. Export Students to JSON");
				Console.WriteLine("7. Import Students from Excel");
				Console.WriteLine("8. Export Students to Excel");
				Console.WriteLine("9. Exit");
				Console.Write("Enter your choice: ");

				string choice = Console.ReadLine();
				Console.WriteLine();

				switch (choice)
				{
					case "1":
						AddStudent();
						break;

					case "2":
						RemoveStudent();
						break;

					case "3":
						UpdateStudent();
						break;

					case "4":
						ListStudents();
						break;

					case "5":
						ImportStudentsFromJson();
						break;

					case "6":
						ExportStudentsToJson();
						break;

					case "7":
						ImportStudentsFromExcel();
						break;

					case "8":
						ExportStudentsToExcel();
						break;

					case "9":
						exit = true;
						break;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}

		private static void AddStudent()
		{
			try
			{
				Console.Write("Enter Id: ");
				int id = int.Parse(Console.ReadLine());

				Console.Write("Enter Name: ");
				string name = Console.ReadLine();

				Console.Write("Enter Age: ");
				int age = int.Parse(Console.ReadLine());

				var student = new Student { Id = id, Name = name, Age = age };
				management.AddStudent(student);
				Console.WriteLine("Student added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error adding student: " + ex.Message);
			}
		}

		private static void RemoveStudent()
		{
			try
			{
				Console.Write("Enter Id to remove: ");
				int id = int.Parse(Console.ReadLine());
				management.RemoveStudent(id);
				Console.WriteLine("Student removed successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error removing student: " + ex.Message);
			}
		}

		private static void UpdateStudent()
		{
			try
			{
				Console.Write("Enter Id to update: ");
				int id = int.Parse(Console.ReadLine());
				var student = management.GetStudent(id);
				if (student == null)
				{
					Console.WriteLine("Student not found.");
					return;
				}

				Console.Write($"Enter new Name (current: {student.Name}): ");
				string name = Console.ReadLine();
				Console.Write($"Enter new Age (current: {student.Age}): ");
				int age = int.Parse(Console.ReadLine());

				// Nếu không nhập gì, giữ nguyên giá trị cũ
				student.Name = string.IsNullOrEmpty(name) ? student.Name : name;
				student.Age = age;
				management.UpdateStudent(student);
				Console.WriteLine("Student updated successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error updating student: " + ex.Message);
			}
		}

		private static void ListStudents()
		{
			var students = management.GetAllStudents();
			if (students.Count == 0)
			{
				Console.WriteLine("No students found.");
				return;
			}
			foreach (var student in students)
			{
				Console.WriteLine(student);
			}
		}

		private static void ImportStudentsFromJson()
		{
			Console.Write("Enter JSON file path: ");
			string filePath = Console.ReadLine();
			management.ImportFromJson(filePath);
			Console.WriteLine("Students imported from JSON successfully.");
		}

		private static void ExportStudentsToJson()
		{
			Console.Write("Enter JSON file path: ");
			string filePath = Console.ReadLine();
			management.ExportToJson(filePath);
			Console.WriteLine("Students exported to JSON successfully.");
		}

		private static void ImportStudentsFromExcel()
		{
			Console.Write("Enter Excel file path: ");
			string filePath = Console.ReadLine();
			management.ImportFromExcel(filePath);
			Console.WriteLine("Students imported from Excel successfully.");
		}

		private static void ExportStudentsToExcel()
		{
			Console.Write("Enter Excel file path: ");
			string filePath = Console.ReadLine();
			management.ExportToExcel(filePath);
			Console.WriteLine("Students exported to Excel successfully.");
		}
	}
}