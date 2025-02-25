using System.Text;
using System.Xml.Serialization;

using C__Student.Models;
using Microsoft.Extensions.DependencyInjection;

namespace C__Student
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<IStudentManagement, StudentManagement>();
			var studentProvider = serviceCollection.BuildServiceProvider();
			var studentManagement = studentProvider.GetRequiredService<IStudentManagement>();

			studentManagement.Add(new Student
			{
				Id = 1,
				Name = "ducnhuad",
				Age = 21
			});
			studentManagement.Add(new Student
			{
				Id = 2,
				Name = "ducnhuad",
				Age = 22
			});
		}
	}
}