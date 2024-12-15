using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        public void ChangeStatusToFalse(int id);
        public void ChangeStatusToTrue(int id);
        public List<Discount> GetStatusTrue();
    }
}
