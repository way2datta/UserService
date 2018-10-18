using System.Collections.Generic;

namespace RegisterUser
{
    internal class UserService : IUserService
    {
        private static readonly List<User> users = new List<User>();
        private readonly INotificationService notificationService = new EmailNotificationService();
        private readonly IValidator<User> validator = new UserValidator();

        public List<User> GetUsers()
        {
            return users;
        }

        public void Register(User user)
        {
            Validate(user);

            StoreUser(user);

            SendNotification(user);
        }

        private static void StoreUser(User user)
        {
            users.Add(user);
        }

        private void SendNotification(User user)
        {
            notificationService.Notify($"User {user} created");
        }

        private void Validate(User user)
        {
            validator.Validate(user);
        }
    }
}