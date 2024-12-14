using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        public List<Notification> GetAllNotificationByFalse();
        public int NotificationCountByStatusFalse();
        public void NotificationStatusChangeToTrue(int id);
        public void NotificationStatusChangeToFalse(int id);
    }
}
