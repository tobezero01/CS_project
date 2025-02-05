using OOP_Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Examples.Services
{
	internal class EmployeeService
	{
		private List<Employee> _employees;

		public EmployeeService()
		{
			_employees = new List<Employee>();
		}

		public EmployeeService(List<Employee> employees)
		{
			_employees = employees;
		}

		public void Create(Employee employee)
		{
			if (employee == null)
			{
				throw new ArgumentNullException("employee  cannot be null");
			}
			_employees.Add(employee);
		}

		public IEnumerable<Employee> GetAll()
		{
			return _employees;
		}

		public Employee GetById(int id)
		{
			Predicate<Employee> filter = e => e.id == id;
			return _employees.Find(filter);
		}

		public void Update(int id, Employee employee)
		{
			var entity = GetById(id);
			if (entity == null)
			{
				throw new ArgumentNullException("employee cannot be found");
			}
			entity.id = entity.id;
			entity.name = employee.name;
			entity.Email = employee.Email;
			entity.DateOfBirth = employee.DateOfBirth;
		}

		public void Delete(int id)
		{
			var entity = GetById(id);
			if (entity == null)
			{
				throw new ArgumentNullException("employee cannot be found");
			}
			_employees.Remove(entity);
		}
	}
}