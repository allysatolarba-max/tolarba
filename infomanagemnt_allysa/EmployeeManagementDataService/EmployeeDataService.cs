using EmployeeManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDataService
{
    public class EmployeeDataService
    {
        IEmployeeManagement dataservice;
        public EmployeeDataService(IEmployeeManagement employeedataservice)
        {
            dataservice = employeedataservice;
        }
        public void Add(Employee employee)
        {
            dataservice.Add(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            dataservice.UpdateEmployee(employee);
        }
        public void PromoteEmployee(Employee employee)
        {
            dataservice.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Guid id)
        {
            dataservice.DeleteEmployee(id);
        }
        public Employee? GetById(Guid id)
        {
            return dataservice.GetById(id);
        }
        public List<Employee> GetEmployees()
        {
            return dataservice.GetEmployees();
        }
        public bool EmployeeExists(string name)
        {
            return dataservice.EmployeeExists(name);
        }
    }
}
