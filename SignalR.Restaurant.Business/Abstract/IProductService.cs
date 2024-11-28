using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
    }
}
