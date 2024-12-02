using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        public int TProductCountByCategoryNameHamburger();
        public int TProductCountByCategoryNameDrink();
        public decimal TProductPriceAvg();
        public string TProductNameByMaxPrice();
        public string TProductNameByMinPrice();
        public decimal TProductAvgPriceByHamburger();
    }
}
