using WebApp.Entities.Concrete;
using WebApp.Core.Models;

namespace WebApp.Business.Abstract
{
    public interface IBookingService
    {
        GetManyResult<Booking> GetAllBookings();
        GetOneResult<Booking> GetBookingById(string id);
        GetOneResult<Booking> AddBooking(Booking booking);
        GetOneResult<Booking> UpdateBooking(Booking booking);
        GetOneResult<Booking> CancelBooking(string id);
    }
}
