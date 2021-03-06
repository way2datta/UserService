﻿using System;
using Autofac;
using RegisterUser.ClassLibrary;

namespace RegisterUser
{
    internal class Program
    {
        private readonly IUserService userService;

        public Program(IUserService userService)
        {
            this.userService = userService;
        }

        private static IContainer ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterInstance(new EmailNotificationSender())
                   .As<INotificationSender>();
            builder.RegisterInstance(new UserValidator()).As<IValidator<User>>();

            var container = builder.Build();
            return container;
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
            var container = ConfigureAutofac();

            IUserService userService;

            using (var scope = container.BeginLifetimeScope())
            {
                userService = scope.Resolve<IUserService>();
            }

            var program = new Program(userService);

            do
            {
                Console.Clear();

                program.DisplayUsers();

                var userFromConsole = GetUserFromConsole();

                program.userService.Register(userFromConsole);

                Console.WriteLine("Do you want to continue (Y/N)? ");
            } while (Console.ReadKey().KeyChar != 'n');
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
    }
}