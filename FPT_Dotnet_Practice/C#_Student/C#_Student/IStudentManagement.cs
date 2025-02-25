using C__Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Student
{
	public interface IStudentManagement
	{
		/// <summary>
		/// Adds the specified student.
		/// </summary>
		/// <param name="student">The student.</param>
		void Add(Student student);

		/// <summary>
		/// Removes the student.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public void Remove(int id);

		/// <summary>
		/// Updates the student.
		/// </summary>
		/// <param name="updatedStudent">The updated student.</param>
		public void Update(Student updatedStudent);

		/// <summary>
		/// Gets the student.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public Student GetById(int id);

		/// <summary>
		/// Gets all students.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Student> GetAll();

		/// <summary>
		/// Imports from json.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ImportFromJson(string filePath);

		/// <summary>
		/// Exports to json.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ExportToJson(string filePath);

		/// <summary>
		/// Imports from excel.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ImportFromExcel(string filePath);

		/// <summary>
		/// Exports to excel.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		public void ExportToExcel(string filePath);
	}
}