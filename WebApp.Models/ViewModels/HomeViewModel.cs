using System.Collections.Generic;
using WebApp.Entities.Concrete;

namespace WebApp.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PropertyViewModel>? FeaturedProperties { get; set; }
        public IEnumerable<TestimonialViewModel>? Testimonials { get; set; }
    }

    public class PropertyViewModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
    }

    public class TestimonialViewModel
    {
        public string? UserName { get; set; }
        public string? Comment { get; set; }
    }
}
