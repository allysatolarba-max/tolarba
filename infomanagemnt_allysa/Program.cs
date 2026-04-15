using System;
using EmployeeManagementModels;
using EmployeeManagementAppService;

namespace EmployeeManagementUI
{
    class Program
    {
        static EmployeeAppService service = new EmployeeAppService();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("===== EMPLOYEE MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Hire Employee");
                Console.WriteLine("2. Promote Employee");
                Console.WriteLine("3. Transfer Department");
                Console.WriteLine("4. View Employees");
                Console.WriteLine("5. Remove Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        HireEmployee();
                        break;

                    case 2:
                        PromoteEmployee();
                        break;

                    case 3:
                        TransferEmployee();
                        break;

                    case 4:
                        ViewEmployees();
                        break;

                    case 5:
                        RemoveEmployee();
                        break;

                    case 6:
                        Console.WriteLine("Exiting System...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

            } while (choice != 5);
        }

        static void HireEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Employee emp = new Employee
            {
                Name = name,
                Position = position,
                Department = department,
                Salary = salary
            };

            bool success = service.HireEmployee(emp);

            if (success)
                Console.WriteLine("\nEmployee hired successfully!");
            else
                Console.WriteLine("\nEmployee already exists.");
        }

        static void PromoteEmployee()
        {
            var employees = service.GetEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees available.");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i}. {employees[i].Name} - {employees[i].Position}");
            }

            Console.Write("Enter Employee Number: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Position: ");
            string newPosition = Console.ReadLine();

            Console.Write("Enter Salary Increase: ");
            double increase = Convert.ToDouble(Console.ReadLine());

            service.PromoteEmployee(employees[index].EmployeeId, newPosition, increase);

            Console.WriteLine("Employee promoted successfully!");
        }

        static void TransferEmployee()
        {
            var employees = service.GetEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees available.");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i}. {employees[i].Name} - {employees[i].Department}");
            }

            Console.Write("Enter Employee Number: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Department: ");
            string newDepartment = Console.ReadLine();

            service.TransferEmployee(employees[index].EmployeeId, newDepartment);

            Console.WriteLine("Employee transferred successfully!");
        }

        static void ViewEmployees()
        {
            var employees = service.GetEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees available.");
                return;
            }

            foreach (var emp in employees)
            {
                Console.WriteLine("\nEmployee Information");
                Console.WriteLine("Name: " + emp.Name);
                Console.WriteLine("Position: " + emp.Position);
                Console.WriteLine("Department: " + emp.Department);
                Console.WriteLine("Salary: " + emp.Salary);
            }
        }
        static void RemoveEmployee() { 
        
            var employees = service.GetEmployees();
            if (employees.Count == 0) 
            {
                Console.WriteLine("No Employees Available.");
                return;
            }
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i}.{employees[i].Name}");
            }

            Console.Write("Enter Employee Number to Remove: ");
            int index = Convert.ToInt32(Console.ReadLine());

            bool success = service.RemoveEmployee(employees[index].EmployeeId);

            if (success)
            {
                Console.WriteLine("Employee Removed Successfully!");
            } 
            else
            {
                Console.WriteLine("Inavalid Employee.");
            }
        }
    }
}