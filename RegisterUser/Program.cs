using System;
using Autofac;

namespace RegisterUser
{
    internal class Program
    {
        private IUserService userService;

        public Program(IUserService userService)
        {
            this.userService = userService;
        }

        private void DisplayUsers()
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
            var builder = new ContainerBuilder();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterInstance(new EmailNotificationService())
                   .As<INotificationService>();
            builder.RegisterInstance(new UserValidator()).As<IValidator<User>>();

            var container = builder.Build();

            do
            {
                Console.Clear();

                IUserService userService;

                using (var scope = container.BeginLifetimeScope())
                {
                    userService = scope.Resolve<IUserService>();
                }

                var program = new Program(userService);

                program.DisplayUsers();

                var userFromConsole = GetUserFromConsole();

                program.userService.Register(userFromConsole);

                Console.WriteLine("Do you want to continue (Y/N)? ");
            } while (Console.ReadKey().KeyChar != 'n');
        }
    }
}