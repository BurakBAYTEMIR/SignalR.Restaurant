using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        public int TTotalOrderCount();
        public int TActiveOrderCount();
        public decimal TLastOrderPrice();
    }
}
