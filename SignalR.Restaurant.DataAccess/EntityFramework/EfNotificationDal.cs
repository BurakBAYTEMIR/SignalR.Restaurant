using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using (var context = new SignalRContext())
            {
                return context.Notifications.Where(x => x.Status == false).ToList();
            }
        }

        public int NotificationCountByStatusFalse()
        {
            using (var context = new SignalRContext())
            {
                return context.Notifications.Where(x => x.Status == false).Count();
            }
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.Notifications.Find(id);
                value.Status = false;
                context.SaveChanges();
            }
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.Notifications.Find(id);
                value.Status = true;
                context.SaveChanges();
            }
        }
    }
}
