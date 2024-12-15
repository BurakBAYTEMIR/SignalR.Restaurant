using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.DataAccess.Repositories;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using (var context = new SignalRContext())
            {
                var values = context.Bookings.Find(id);
                values.BookingDescription = "Rezervasyon Onaylandı";
                context.SaveChanges();
            }
        }

        public void BookingStatusCancelled(int id)
        {
            using (var context = new SignalRContext())
            {
                var values = context.Bookings.Find(id);
                values.BookingDescription = "Rezervasyon İptal Edildi";
                context.SaveChanges();
            }
        }
    }
}
