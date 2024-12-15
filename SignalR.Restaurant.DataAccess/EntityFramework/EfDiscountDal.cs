using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.Discounts.Find(id);
                value.DiscountStatus = false;
                context.SaveChanges();
            }
        }

        public void ChangeStatusToTrue(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.Discounts.Find(id);
                value.DiscountStatus = true;
                context.SaveChanges();
            }
        }

        public List<Discount> GetStatusTrue()
        {
            using (var context = new SignalRContext())
            {
                var value = context.Discounts.Where(x => x.DiscountStatus == true).ToList();
                return value;
            }
        }
    }
}
