namespace Habit360.Domain.Notifications
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;

        public Notificator()
        {
            _notifications = [];
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {   
            return _notifications.Count != 0;
        }

        public List<Notification> GetAllNotifications() 
        {
            return _notifications;
        }
    }
}
