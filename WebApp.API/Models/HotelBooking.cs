using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApp.API.Models
{
    public class HotelBooking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public string ClientName { get; set; }
    }
}

