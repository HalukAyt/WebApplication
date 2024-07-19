using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApp.DataAccess.Context;
using MongoDB.Bson;
using WebApp.Entities.Concrete;
using WebApp.API.Models;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public BookingController(MongoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit([FromBody] HotelBooking booking)
        {
            var collection = _context.GetCollection<HotelBooking>();
            if (string.IsNullOrEmpty(booking.Id))
            {
                booking.Id = ObjectId.GenerateNewId().ToString();
                await collection.InsertOneAsync(booking);
            }
            else
            {
                var filter = Builders<HotelBooking>.Filter.Eq(b => b.Id, booking.Id);
                var updateResult = await collection.ReplaceOneAsync(filter, booking);

                if (updateResult.MatchedCount == 0)
                    return NotFound();
            }

            return Ok(booking);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var collection = _context.GetCollection<HotelBooking>();
            var filter = Builders<HotelBooking>.Filter.Eq(b => b.Id, id);
            var booking = await collection.Find(filter).FirstOrDefaultAsync();

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var collection = _context.GetCollection<HotelBooking>();
            var filter = Builders<HotelBooking>.Filter.Eq(b => b.Id, id);
            var deleteResult = await collection.DeleteOneAsync(filter);

            if (deleteResult.DeletedCount == 0)
                return NotFound();

            return NoContent();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var collection = _context.GetCollection<HotelBooking>();
            var bookings = await collection.Find(_ => true).ToListAsync();
            return Ok(bookings);
        }
    }
}
