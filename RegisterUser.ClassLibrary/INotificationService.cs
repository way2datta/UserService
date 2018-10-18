namespace RegisterUser.ClassLibrary
{
    public interface INotificationSender
    {
        void SendNotification(string message);
    }
}