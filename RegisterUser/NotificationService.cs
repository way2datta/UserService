using System;

namespace RegisterUser
{
    internal class EmailNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine(message + " `sent via email`");
        }
    }
}