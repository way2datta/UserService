using System;

namespace RegisterUser
{
    interface INotificationService
    {
        void Notify(string message); 
    }

    internal class EmailNotificationService : INotificationService
    {
        public void Notify(string message) 
        {
            Console.WriteLine(message +" `sent via email`");
        }
    }
}