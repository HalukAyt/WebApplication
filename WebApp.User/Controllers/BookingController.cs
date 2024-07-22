using Microsoft.AspNetCore.Mvc;
using WebApp.Business.Abstract;
using WebApp.Entities.Concrete;

namespace WebApp.User.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var bookings = _bookingService.GetAllBookings();
            return View(bookings.Result);
        }

        public IActionResult Details(string id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking.Entity == null)
            {
                return NotFound();
            }
            return View(booking.Entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingService.AddBooking(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking.Entity == null)
            {
                return NotFound();
            }
            return View(booking.Entity);
        }

        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingService.UpdateBooking(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        public IActionResult Cancel(string id)
        {
            var result = _bookingService.CancelBooking(id);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
