using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TChangeStatusToFalse(int id)
        {
            _discountDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _discountDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount TGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public List<Discount> TGetStatusTrue()
        {
            return _discountDal.GetStatusTrue();
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
