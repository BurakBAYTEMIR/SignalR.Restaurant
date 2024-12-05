using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            using (var context = new SignalRContext())
            {
                return context.MenuTables.Count();
            }
        }
    }
}
