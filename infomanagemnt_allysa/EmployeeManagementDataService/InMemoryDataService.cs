using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class InMemoryDataService
    {
        public List<Employee> dummyEmployees = new List<Employee>();

        public InMemoryDataService()
        {
            Employee emp1 = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                Name = "John",
                Position = "Manager",
                Department = "HR",
                Salary = 50000
            };

            Employee emp2 = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                Name = "Anna",
                Position = "Developer",
                Department = "IT",
                Salary = 40000
            };

            dummyEmployees.Add(emp1);
            dummyEmployees.Add(emp2);
        }

        public void Add(Employee employee)
        {
            dummyEmployees.Add(employee);
        }

        public Employee? GetById(Guid id)
        {
            return dummyEmployees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public bool EmployeeExists(string name)
        {
            return dummyEmployees.Any(e => e.Name == name);
        }

        public void Update(Employee employee)
        {
         
            var existing = GetById(employee.EmployeeId);

            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Department = employee.Department;
                existing.Salary = employee.Salary;
            }
        }


        public List<Employee> GetEmployees()
        {
            return dummyEmployees;
        }
    }
}