
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public class Program
    {
        public class Users // Users class to store the users of the program
        {
            public Dictionary<int, string> users = new Dictionary<int, string>
            {
                {1, "Alex"},
                {2, "Blake"},
                {3, "Charlie"},
                {4, "Drew"},
                {5, "Eli"},
                {6, "Frank"},
                {7, "Gale"},
                {8, "Hunter"},
                {9, "Izzy"},
                {10, "Jordan"},
                {11, "Kai"},
                {12, "Lee"},
                {13, "Morgan"},
                {14, "Pat"},
                {15, "Quinn"},
                {16, "Riley"},
                {17, "Sam"},
                {18, "Taylor"},
                {19, "Tyler"},
                {20, "Val"}
            };
        }

        public class Functionality // Functionality class to store the functions of the program
        {
            public Dictionary<int, string> Functions = new Dictionary<int, string>
            {
                {1, "View All Users"},
                {2, "Add User"},
                {3, "Edit User"},
                {4, "Search User"},
                {5, "Remove User"},
                {6, "Exit"}
            };
        }

        static void Main()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Welcome to my management system {name}!");

            DisplayOptions();

            Console.WriteLine("Please select an option: ");

            AddUser();
        }

        public static void DisplayOptions() // DisplayOptions method to display the options of the program
        {
            Functionality functions = new Functionality();
            foreach (var function in functions.Functions)
            {
                Console.WriteLine($"{function.Key}. {function.Value}");
            }
        }

        public static void ViewUsers()
        {
            Users users = new Users();
            foreach (var user in users.users)
            {
                Console.WriteLine($"{user.Key}. {user.Value}");
            }
        }

        public static void AddUser()
        {
            Users users = new Users();

            string newUser;
            int id;


            while (true)
            {
                Console.WriteLine("Please enter the name of the user: ");
                newUser = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newUser))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
            }
            
            while (true)
            {
                Console.WriteLine("Please enter the ID of the user: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }

            if (users.users.ContainsKey(id)) // Check if the user already exists
            {
                Console.WriteLine("User already exists!");
            }
            else
            {
                users.users.Add(id, newUser);
                Console.WriteLine("User added successfully!");
            }
        }

        public static void RemoveUser()
        {
            
        }
    }       
}









// Can use a switch statement to call the methods based on the user's input


