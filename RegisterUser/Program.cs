using System;

namespace RegisterUser
{
    internal class Program
    {
        private static IUserService userService = new UserService();

        private static void DisplayUsers()
        {
            var users = userService.GetUsers();

            Console.WriteLine("Number of users present in the system are: " + users.Count);

            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private static User GetUserFromConsole()
        {
            var userFromConsole = new User();
            Console.WriteLine("Enter your name: ");
            userFromConsole.Name = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            userFromConsole.Email = Console.ReadLine();
            return userFromConsole;
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                DisplayUsers();

                var userFromConsole = GetUserFromConsole();

                userService.Register(userFromConsole);

                Console.WriteLine("Do you want to continue (Y/N)? ");
            } while (Console.ReadKey().KeyChar != 'n');
        }
    }
}