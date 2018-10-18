using System.Collections.Generic;

namespace RegisterUser.ClassLibrary
{
    public class UserService : IUserService
    {
        private static readonly List<User> users = new List<User>();

        private readonly INotificationSender notificationService;
        private readonly IValidator<User> validator;

        public UserService(INotificationSender notificationService, IValidator<User> validator)
        {
            this.notificationService = notificationService;
            this.validator = validator;
        }

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
            notificationService.SendNotification($"User {user} created");
        }

        private void Validate(User user)
        {
            validator.Validate(user);
        }
    }
}