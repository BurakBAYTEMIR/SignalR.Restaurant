using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        public List<Notification> TGetAllNotificationByFalse();
        public int TNotificationCountByStatusFalse();
        public void TNotificationStatusChangeToTrue(int id);
        public void TNotificationStatusChangeToFalse(int id);
    }
}
