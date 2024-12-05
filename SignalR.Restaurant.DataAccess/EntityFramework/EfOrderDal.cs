using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using (var context = new SignalRContext())
            {
                return context.Orders
                    .Where(x => x.Description == "Müşteri Masada").Count();
            }
        }

        public decimal LastOrderPrice()
        {
            using (var context = new SignalRContext())
            {
                return context.Orders
                    .OrderByDescending(x => x.OrderID)
                    .Take(1)
                    .Select(y => y.TotalPrice)
                    .FirstOrDefault();
            }
        }

        public int TotalOrderCount()
        {
            using (var context = new SignalRContext())
            {
                return context.Orders.Count();
            }
        }
    }
}
