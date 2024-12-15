using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        public void TBookingStatusApproved(int id);
        public void TBookingStatusCancelled(int id);
    }
}
