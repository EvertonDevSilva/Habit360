namespace Habit360.Domain.Notifications
{
    public interface INotificator
    {
        void Handle(Notification notificacao);
        bool HasNotification();
        List<Notification> GetAllNotifications();
    }
}
