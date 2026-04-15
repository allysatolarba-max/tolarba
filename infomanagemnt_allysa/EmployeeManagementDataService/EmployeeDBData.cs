using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementModels;
using Microsoft.Data.SqlClient;

namespace EmployeeManagementDataService
{
    public class EmployeeDBData : IEmployeeManagement
    {
        private string connectionString
            = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = EmployeeManagementSystem ; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;
        public EmployeeDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = GetEmployees();
            if (existing.Count == 0)
            {
                Employee Employees = new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Allysa",
                    Position = "Network Engineer",
                    Department = "IT Department",
                    Salary = 200000
                };
              
                 Add(Employees);
              
            }
        }
        public void Add(Employee Employees)
        {
            var insertStatement = "INSERT INTO EmployeeDataBase VALUES (@EmployeeId,@Name,@Position,@Department,@Salary)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@EmployeeId", Employees.EmployeeId);
            insertCommand.Parameters.AddWithValue("@Name", Employees.Name);
            insertCommand.Parameters.AddWithValue("@Position", Employees.Position);
            insertCommand.Parameters.AddWithValue("@Department", Employees.Department);
            insertCommand.Parameters.AddWithValue("@Salary", Employees.Salary);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteEmployee(Guid id)
        {
            sqlConnection.Open();
            var updateStatement = $"DELETE FROM EmployeeDataBase WHERE EmployeeId = @EmployeeId";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@EmployeeId", id);


            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public List<Employee> GetEmployees() {
            string selectStatement = "SELECT EmployeeId, Name, Position, Department, Salary FROM EmployeeDataBase";
            SqlCommand insertCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = insertCommand.ExecuteReader();

            var employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeId = Guid.Parse(reader["EmployeeId"].ToString());
                employee.Name = reader["Name"].ToString();
                employee.Position = reader["Position"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.Salary = Convert.ToInt32(reader["Salary"]);

               employees.Add(employee);
            }
            sqlConnection.Close();
            return employees;
        }

        public Employee? GetById(Guid id)
        {
            var selectStatement = "SELECT EmployeeId, Name, Position, Department, Salary FROM EmployeeDataBase WHERE EmployeeId = @EmployeeId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@EmployeeId", id.ToString());
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var employee = new Employee();

            while (reader.Read())
            {
                employee.EmployeeId = Guid.Parse(reader["EmployeeId"].ToString());
                employee.Name = reader["Name"].ToString();
                employee.Position = reader["Position"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.Salary = Convert.ToDouble(reader["Salary"].ToString());
            }

            sqlConnection.Close();
            return employee;
        }
        public void UpdateEmployee(Employee employee)
        {
          sqlConnection.Open();

            var updateStatement = $"UPDATE EmployeeDataBase SET EmployeeId = @EmployeeId, Position = @Position, Department = @Department, Salary = @Salary WHERE EmployeeId = @EmployeeId ";
            
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            updateCommand.Parameters.AddWithValue("@Position", employee.Position);
            updateCommand.Parameters.AddWithValue("@Department", employee.Department);
            updateCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void PromoteEmployee(Employee employee)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE EmployeeDataBase SET Department = @Department,WHERE EmployeeId = @EmployeeId ";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);


            updateCommand.Parameters.AddWithValue("@Department", employee.Department);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public bool EmployeeExists(string name)
        {
            var selectStatement = "SELECT EmployeeId, Name, Position, Department, Salary FROM EmployeeDataBase WHERE Name = @Name";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Name", name);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var employee = new Employee();

            while (reader.Read())
            {
                employee.EmployeeId = Guid.Parse(reader["EmployeeId"].ToString());
                employee.Name = reader["Name"].ToString();
                employee.Position = reader["Position"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.Salary = Convert.ToInt32(reader["Salary"].ToString());
            }

            sqlConnection.Close();
            return employee.Name != null;
        }

    }
}
