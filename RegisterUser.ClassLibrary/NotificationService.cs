using System;

namespace RegisterUser.ClassLibrary
{
    public class EmailNotificationSender : INotificationSender
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Message: `" + message + "` sent via email.");
        }
    }
}