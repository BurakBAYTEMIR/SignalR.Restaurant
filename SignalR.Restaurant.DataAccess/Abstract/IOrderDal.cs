using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        public int TotalOrderCount();
        public int ActiveOrderCount();
        public decimal LastOrderPrice();
    }
}
