using WebApp.Entities.Concrete;
using WebApp.Core.Models;
using WebApp.DataAccess.Abstract;
using WebApp.Business.Abstract;

namespace WebApp.Business.Concrete
{
    public class BookingService(IBookingDataAccess bookingDataAccess) : IBookingService
    {
        private readonly IBookingDataAccess _bookingDataAccess = bookingDataAccess;

        public GetManyResult<Booking> GetAllBookings()
        {
            return _bookingDataAccess.GetAll();
        }

        public GetOneResult<Booking> GetBookingById(string id)
        {
            return _bookingDataAccess.GetById(id);
        }

        public GetOneResult<Booking> AddBooking(Booking booking)
        {
            return _bookingDataAccess.InsertOne(booking);
        }

        public GetOneResult<Booking> UpdateBooking(Booking booking)
        {
            return _bookingDataAccess.ReplaceOne(booking, booking.Id.ToString());
        }

        public GetOneResult<Booking> CancelBooking(string id)
        {
            var booking = _bookingDataAccess.GetById(id).Entity;
            if (booking != null)
            {
                booking.Status = "Cancelled";
                return _bookingDataAccess.ReplaceOne(booking, booking.Id.ToString());
            }
            return new GetOneResult<Booking> { Success = false, Message = "Booking not found" };
        }
    }
}
