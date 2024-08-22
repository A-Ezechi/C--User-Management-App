namespace ConsoleApp1
{
    public class Program
    {
        static Users users = new Users(); // Shared instance of Users

        static void Main()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Welcome to my management system {name}!");

            while (true)
            {
                Functions.DisplayOptions();
                Console.WriteLine("Please select an option: ");
                
                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            Functions.ViewUsers(users);
                            break;
                        case 2:
                            Functions.AddUser(users);
                            break;
                        case 3:
                            Functions.EditUser(users);
                            break;
                        case 4:
                            Functions.SearchUser(users);
                            break;
                        case 5:
                            Functions.RemoveUser(users);
                            break;
                        case 6:
                            Functions.Exit();
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
    }

    public static class Functions
    {
        public static void DisplayOptions()
        {
            Options options = new Options();
            foreach (var option in options.options)
            {
                Console.WriteLine($"{option.Key}. {option.Value}");
            }
        }

        public static void ViewUsers(Users users)
        {
            foreach (var user in users.users)
            {
                Console.WriteLine($"{user.Key}. {user.Value}");
            }
        }

        public static void AddUser(Users users)
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

        public static void RemoveUser(Users users)
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

        public static void SearchUser(Users users)
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

        public static void EditUser(Users users)
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
