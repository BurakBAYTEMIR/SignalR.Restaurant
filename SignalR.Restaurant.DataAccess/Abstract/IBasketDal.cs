using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByMenuTableNumber(int id);
        List<Basket> GetBasketListByMenuTableWithProductName(int id);
    }
}
