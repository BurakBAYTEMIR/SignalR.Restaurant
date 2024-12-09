using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public Slider TGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
