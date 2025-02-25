using C__Student.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C__Student
{
	public class StudentManagement : IStudentManagement
	{
		private readonly List<Student> students;

		public StudentManagement()
		{
			this.students = new List<Student>();
		}

		#region CRUD Methods

		/// <summary>
		/// Adds the student.
		/// </summary>
		/// <param name="student">The student.</param>
		/// <exception cref="System.ArgumentException">A student with the same Id already exists.</exception>
		public void Add(Student student)
		{
			if (students.Any(s => s.Id == student.Id))
			{
				throw new ArgumentException("A student with the same Id already exists.");
			}
			students.Add(student);
		}

		/// <summary>
		/// Removes the student.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public void Remove(int id)
		{
			var student = GetById(id);
			if (student != null)
			{
				students.Remove(student);
			}
			else
			{
				throw new InvalidOperationException("Student not found with current id");
			}
		}

		/// <summary>
		/// Updates the student.
		/// </summary>
		/// <param name="updatedStudent">The updated student.</param>
		public void Update(Student updatedStudent)
		{
			int index = students.FindIndex(s => s.Id == updatedStudent.Id);
			if (index >= 0)
			{
				students[index] = updatedStudent;
			}
			else
			{
				Console.WriteLine("Student not found.");
			}
		}

		/// <summary>
		/// Gets the student.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public Student GetById(int id)
		{
			return students.FirstOrDefault(s => s.Id == id);
		}

		/// <summary>
		/// Gets all students.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Student> GetAll()
		{
			return students;
		}

		#endregion CRUD Methods

		#region Import/Export

		/// <summary>
		/// Imports from json.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ImportFromJson(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Console.WriteLine("Json File does not exist");
				return;
			}
			string jsonData = File.ReadAllText(filePath);
			var imported = JsonConvert.DeserializeObject<List<Student>>(jsonData);
			if (imported != null)
			{
				foreach (var s in imported)
				{
					students.Add(s);
				}
			}
		}

		/// <summary>
		/// Exports to json.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ExportToJson(string filePath)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
			}
			string jsonData = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(filePath, jsonData);
		}

		/// <summary>
		/// Imports from excel.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ImportFromExcel(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Console.WriteLine("Json File does not exist");
				return;
			}

			ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

			using (var package = new ExcelPackage(new FileInfo(filePath)))
			{
				var workSheet = package.Workbook.Worksheets[0];
				int row = 2;

				while (workSheet.Cells[row, 1].Value != null)
				{
					try
					{
						int id = Convert.ToInt32(workSheet.Cells[row, 1].GetValue<int>());
						string? name = workSheet.Cells[row, 2].GetValue<string>();
						int age = Convert.ToInt32(workSheet.Cells[row, 3].GetValue<int>());
						var student = new Student(id, name, age);
						students.Add(student);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
					row++;
				}
			}
		}

		/// <summary>
		/// Exports to excel.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ExportToExcel(string filePath)
		{
			ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
			using (var package = new ExcelPackage())
			{
				var workSheet = package.Workbook.Worksheets.Add("Student");
				workSheet.Cells[1, 1].Value = "Id";
				workSheet.Cells[1, 2].Value = "Name";
				workSheet.Cells[1, 3].Value = "Age";
				int row = 2;
				foreach (Student s in students)
				{
					workSheet.Cells[row, 1].Value = s.Id;
					workSheet.Cells[row, 2].Value = s.Name;
					workSheet.Cells[row, 3].Value = s.Age;
					row++;
				}
				package.SaveAs(new FileInfo(filePath));
			}
		}

		#endregion Import/Export
	}
}