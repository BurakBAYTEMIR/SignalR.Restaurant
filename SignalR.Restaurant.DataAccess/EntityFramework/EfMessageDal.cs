using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeMessageStatusToFalse(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.Messages.Find(id);
                value.Status = false;
                context.SaveChanges();
            }
        }

        public void ChangeMessageStatusToTrue(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.Messages.Find(id);
                value.Status = true;
                context.SaveChanges();
            }
        }
    }
}
