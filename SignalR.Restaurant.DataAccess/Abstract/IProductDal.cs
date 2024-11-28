using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
    }
}
