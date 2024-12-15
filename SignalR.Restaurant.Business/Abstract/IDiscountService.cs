using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        public void TChangeStatusToFalse(int id);
        public void TChangeStatusToTrue(int id);
        public List<Discount> TGetStatusTrue();
    }
}
