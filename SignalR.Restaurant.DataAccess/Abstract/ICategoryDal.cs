using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public int CategoryCount();
        public int ActiveCategoryCount();
        public int PassiveCategoryCount();
    }
}
