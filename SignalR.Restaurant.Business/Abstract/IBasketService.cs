using SignalR.Restaurant.Dtos.BasketDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        public List<Basket> TGetBasketByMenuTableNumber(int id);
        public List<ResultBasketListWithProducts> TGetBasketListByMenuTableWithProductName(int id);
    }
}
