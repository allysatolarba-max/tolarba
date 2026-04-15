using EmployeeManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDataService
{
    public interface IEmployeeManagement
    {
        void Add(Employee employee);
        Employee? GetById(Guid id);
        void UpdateEmployee(Employee employee);
        void PromoteEmployee(Employee employee);
        void DeleteEmployee(Guid id);
        bool EmployeeExists(string name);
        List<Employee> GetEmployees();
    
    }
}
