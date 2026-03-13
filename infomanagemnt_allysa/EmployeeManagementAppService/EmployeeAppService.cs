using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementModels;
using EmployeeManagementDataService;

namespace EmployeeManagementAppService
{
    public class EmployeeAppService
    {
        EmployeeDataService employeeDataService = new EmployeeDataService();

        public bool HireEmployee(Employee newEmployee)
        {
            if (employeeDataService.EmployeeExists(newEmployee.Name))
                return false;

            var employee = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                Name = newEmployee.Name,
                Position = newEmployee.Position,
                Department = newEmployee.Department,
                Salary = newEmployee.Salary
            };

            employeeDataService.Add(employee);
            return true;
        }

        public bool PromoteEmployee(Guid employeeId, string newPosition, double increase)
        {
            var employee = employeeDataService.GetById(employeeId);

            if (employee == null)
                return false;

            employee.Position = newPosition;
            employee.Salary += increase;

            employeeDataService.Update(employee);

            return true;
        }

        public bool TransferEmployee(Guid employeeId, string newDepartment)
        {
            var employee = employeeDataService.GetById(employeeId);

            if (employee == null)
                return false;

            employee.Department = newDepartment;

            employeeDataService.Update(employee);

            return true;
        }

        public List<Employee> GetEmployees()
        {
            return employeeDataService.GetEmployees();
        }

        public Employee? GetEmployee(Guid employeeId)
        {
            return employeeDataService.GetById(employeeId);
        }
    }
}