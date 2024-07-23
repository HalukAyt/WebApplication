using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Entities.Concrete
{
    public class Property : BaseModel
    {
       [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

       [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

      [Required(ErrorMessage = "Price per night is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal PricePerNight { get; set; }

       [Required(ErrorMessage = "Owner ID is required")]
        public string? OwnerId { get; set; }

       public ICollection<string> Images { get; set; } = [];
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public bool IsFeatured { get; set; }
        public string? ImageUrl { get; set; }
    }
}

