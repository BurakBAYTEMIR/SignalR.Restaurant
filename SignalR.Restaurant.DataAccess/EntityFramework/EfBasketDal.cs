using Microsoft.EntityFrameworkCore;
using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }       

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using (var context = new SignalRContext())
            {
                var values = context.Baskets.
                    Where(x => x.MenuTableID == id).
                    Include(y => y.Product).
                    ToList();
                return values;
            }
        }

        public List<Basket> GetBasketListByMenuTableWithProductName(int id)
        {
            using (var context = new SignalRContext())
            {
                var values = context.Baskets
                    .Include(x => x.Product)
                    .Where(y => y.MenuTableID == id)
                    .ToList();
                return values;
            }
        }
    }
}
