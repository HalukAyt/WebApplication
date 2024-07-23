using WebApp.Entities.Concrete;
using WebApp.Core.Models;
using WebApp.DataAccess.Abstract;
using WebApp.Business.Abstract;
using System;
using System.Linq;

namespace WebApp.Business.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDataAccess _bookingDataAccess;

        public BookingService(IBookingDataAccess bookingDataAccess)
        {
            _bookingDataAccess = bookingDataAccess;
        }

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

        public bool CheckAvailability(string propertyId, DateTime startDate, DateTime endDate)
        {
            var bookings = _bookingDataAccess.FilterBy(b => b.PropertyId == propertyId && b.Status == "Confirmed").Result;
            foreach (var booking in bookings)
            {
                if (startDate < booking.EndDate && endDate > booking.StartDate)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
