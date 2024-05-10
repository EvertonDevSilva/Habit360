namespace Habit360.Notifications
{
    public interface INotificator
    {
        void Handle(Notification notificacao);
        bool HasNotification();
        List<Notification> GetAllNotifications();
    }
}
