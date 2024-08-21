
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

        public class Options // Options class to store the options of the program
        {
            public Dictionary<int, string> options = new Dictionary<int, string>
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

        }

        public static void DisplayOptions() // DisplayOptions method to display the options of the program
        {
            Options options = new Options();
            foreach (var option in options.options)
            {
                Console.WriteLine($"{option.Key}. {option.Value}");
            }
        }

        public static void ViewUsers() // ViewUsers method to view all the users of the program
        {
            Users users = new Users();
            foreach (var user in users.users)
            {
                Console.WriteLine($"{user.Key}. {user.Value}");
            }
        }

        public static void AddUser() // AddUser method to add a user to the program
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

            if (users.users.ContainsKey(id)) // Check if the user already exists with their id key
            {
                Console.WriteLine("User already exists!");
            }
            else
            {
                users.users.Add(id, newUser);
                Console.WriteLine("User added successfully!");
            }
        }

        public static void RemoveUser()  // RemoveUser method to remove a user from the program
        {
            Users users = new Users();

            int deletedUserID;

            while (true)
            {
                Console.WriteLine("Please enter the ID of the user you would like to delete: ");

                if (int.TryParse(Console.ReadLine(), out deletedUserID))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }

            if (users.users.ContainsKey(deletedUserID))
            {
                users.users.TryGetValue(deletedUserID, out string? deletedUser);

                users.users.Remove(deletedUserID);

                Console.WriteLine($"User: {deletedUser} removed successfully!");

                ViewUsers();
            }
            else
            {
                Console.WriteLine("User does not exist!");
            }
        }


    }       
}









// Can use a switch statement to call the methods based on the user's input


