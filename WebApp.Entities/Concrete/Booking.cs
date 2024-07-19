using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApp.Entities.Concrete
{
    public class Booking : BaseModel
    {
        public string PropertyId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Confirmed", "Cancelled"
    }
}
