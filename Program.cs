using System;
using System.Collections.Generic;

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

        static Users users = new Users(); // Shared instance of Users

        static void Main()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Welcome to my management system {name}!");

            while (true)
            {
                DisplayOptions();
                Console.WriteLine("Please select an option: ");
                
                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            ViewUsers();
                            break;
                        case 2:
                            AddUser();
                            break;
                        case 3:
                            EditUser();
                            break;
                        case 4:
                            SearchUser();
                            break;
                        case 5:
                            RemoveUser();
                            break;
                        case 6:
                            Exit();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        public static void DisplayOptions()
        {
            Options options = new Options();
            foreach (var option in options.options)
            {
                Console.WriteLine($"{option.Key}. {option.Value}");
            }
        }

        public static void ViewUsers()
        {
            foreach (var user in users.users)
            {
                Console.WriteLine($"{user.Key}. {user.Value}");
            }
        }

        public static void AddUser()
        {
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

            if (users.users.ContainsKey(id))
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
            }
            else
            {
                Console.WriteLine("User does not exist!");
            }
        }

        public static void SearchUser()
        {
            int foundUserID;

            while (true)
            {
                Console.WriteLine("Please enter the ID of the user you would like to search for: ");
                if (int.TryParse(Console.ReadLine(), out foundUserID))
                {
                    if (users.users.TryGetValue(foundUserID, out string foundUser))
                    {
                        Console.WriteLine($"User: {foundUser} found!");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }
        }

        public static void EditUser()
        {
            int editedUserID;

            while (true)
            {
                Console.WriteLine("Please enter the ID of the user you would like to edit: ");
                if (int.TryParse(Console.ReadLine(), out editedUserID))
                {
                    if (users.users.ContainsKey(editedUserID))
                    {
                        Console.WriteLine("Please enter the new name of the user: ");
                        string newName = Console.ReadLine();
                        users.users[editedUserID] = newName;
                        Console.WriteLine("User updated successfully!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("User ID not found. Please enter a valid ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }
        }

        public static void Exit()
        {
            Console.WriteLine("Exiting program... Goodbye!");
            Environment.Exit(0);
        }
    }
}
