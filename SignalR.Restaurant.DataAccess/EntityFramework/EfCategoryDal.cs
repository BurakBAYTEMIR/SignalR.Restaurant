using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using (var context = new SignalRContext())
            {
                return context.Categories.Where(x => x.Status == true).Count();
            }
        }

        public int CategoryCount()
        {
            using (var context = new SignalRContext())
            {
                return context.Categories.Count();
            }
        }

        public int PassiveCategoryCount()
        {
            using (var context = new SignalRContext())
            {
                return context.Categories.Where(x => x.Status == false).Count();
            }
        }
    }
}
