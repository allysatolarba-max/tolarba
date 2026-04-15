using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class EmployeeJson : IEmployeeManagement
    {
        private List<Employee> emp = new List<Employee>();

        private string _jsonFileName;
        public EmployeeJson()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/empjson.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (emp.Count <= 0)
            {
                emp.Add(new Employee { EmployeeId = Guid.NewGuid() });
                emp.Add(new Employee { Name = "Allysa" });
                emp.Add(new Employee { Position = "Employer" });
                emp.Add(new Employee { Department = "IT" });
                emp.Add(new Employee { Salary = 1000 });

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Employee>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , emp);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.emp = JsonSerializer.Deserialize<List<Employee>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }
        public void Add(Employee employee)
        {
            emp.Add(employee);
            SaveDataToJsonFile();
        }
        public List<Employee> GetEmployees()
        {
            RetrieveDataFromJsonFile();
            return emp;
        }
        public Employee? GetById(Guid id)
        {
            RetrieveDataFromJsonFile();
            return emp.FirstOrDefault(t => t.EmployeeId == id);
        }
        public bool EmployeeExists(string name)
        {
            return emp.Any(e => e.Name == name);
        }
        public void UpdateEmployee(Employee employee)
        {
            RetrieveDataFromJsonFile();

            var existing = emp.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);

            if (existing != null)
            {
                existing.Position = employee.Position;
                existing.Department = employee.Department;
                existing.Salary = employee.Salary;
            }
            SaveDataToJsonFile();
        }

        public void PromoteEmployee(Employee employee)
        {
            RetrieveDataFromJsonFile();

            var existing = emp.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);

            if (existing != null)
            {

              existing.Department = employee.Department;

            }
            SaveDataToJsonFile();
        }
        public void DeleteEmployee(Guid id)
        {
            RetrieveDataFromJsonFile();

            var ExistingEmp = emp.FirstOrDefault(x => x.EmployeeId == id);
            if (ExistingEmp != null)
            {
                emp.Remove(ExistingEmp);
            }
            SaveDataToJsonFile();
        }
    }
}
