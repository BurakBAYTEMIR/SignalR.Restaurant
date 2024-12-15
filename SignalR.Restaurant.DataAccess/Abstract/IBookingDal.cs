using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        public void BookingStatusApproved(int id);
        public void BookingStatusCancelled(int id);
    }
}
