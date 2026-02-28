namespace infomanagemnt_allysa
{
    internal class Program
    {
        static string[] names = new string[5];
        static string[] positions = new string[5];
        static string[] departments = new string[5];
        static double[] salaries = new double[5];
        static int count = 0;

        static void Main(string[] args)
        {
            int choice;

            do
            {

                Console.WriteLine("===== EMPLOYEE INFORMATION SYSTEM =====");
                Console.WriteLine("1. Hire Employee");
                Console.WriteLine("2. Promote Employee");
                Console.WriteLine("3. Transfer Department");
                Console.WriteLine("4. View Employees");
                Console.WriteLine("5. Exit");
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
                        Console.WriteLine("Exiting System...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (choice != 5);
        }

        static void HireEmployee()
        {
            if (count > 5)
            {
                Console.WriteLine("\nEmployee Limit Reached.");
                return;
            }

            string more = "Y";

            while (more.ToUpper() == "Y" && count < 5)
            {
                Console.Write("Enter Name: ");
                names[count] = Console.ReadLine();

                Console.Write("Enter Position: ");
                positions[count] = Console.ReadLine();

                Console.Write("Enter Department: ");
                departments[count] = Console.ReadLine();

                Console.Write("Enter Salary: ");
                salaries[count] = Convert.ToDouble(Console.ReadLine()); // simple

                count++;
                Console.WriteLine("\nEMPLOYEE HIRED SUCCESSFULLY!");

                if (count < 5)
                {
                    Console.Write("\nDo You Want To Hire Another Employee? (Y/N): ");
                    more = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nReached Maximum Employee Limit!");
                }
            }
        }

        static void PromoteEmployee()
        {
            if (count == 0)
            {
                Console.WriteLine("\nNo employees available.");
                return;
            }

            Console.WriteLine("\nEmployees:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i}. {names[i]} - {positions[i]}, {departments[i]}");
            }

            Console.Write("\nEnter the Number of the Employee to Promote: ");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index >= 0 && index < count)
            {
                Console.Write("\nEnter New Position: ");
                positions[index] = Console.ReadLine();

                Console.Write("\nEnter Salary Increase: ");
                double increase = Convert.ToDouble(Console.ReadLine());

                salaries[index] += increase;
                Console.WriteLine($"\n{names[index]} PROMOTED SUCCESSFULLY!");
            }
            else
            {
                Console.WriteLine("\nInvalid Employee Number.");
            }
        }

        static void TransferEmployee()
        {
            if (count == 0)
            {
                Console.WriteLine("\nNo Employees Available.");
                return;
            }

            Console.WriteLine("\nEmployees:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i}. {names[i]} - {positions[i]}, {departments[i]}");
            }

            Console.Write("\nEnter The Number of the Employee to Transfer: ");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index >= 0 && index < count)
            {
                Console.Write("\nEnter New Department: ");
                departments[index] = Console.ReadLine();
                Console.WriteLine($"\n{names[index]} TRANSFERRED SUCCESSFULLY!");
            }
            else
            {
                Console.WriteLine("\nInvalid Employee Number.");
            }
        }

        static void ViewEmployees()
        {
            if (count == 0)
            {
                Console.WriteLine("\nNo Employees Available.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEmployee #{i}");
                Console.WriteLine("Name: " + names[i]);
                Console.WriteLine("Position: " + positions[i]);
                Console.WriteLine("Department: " + departments[i]);
                Console.WriteLine("Salary: " + salaries[i]);
            }
        }
    }
}