using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using System.Collections.Generic;
using WebApp.Business.Abstract;
using WebApp.Entities.Concrete;

namespace WebApp.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService _propertyService;

        public HomeController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var featuredProperties = GetFeaturedProperties();
            var testimonials = GetTestimonials();

            var model = new HomeViewModel
            {
                FeaturedProperties = featuredProperties,
                Testimonials = testimonials
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string location, DateTime? startDate, DateTime? endDate, decimal? priceRange)
        {
            var properties = _propertyService.GetAllProperties().Result;

            if (!string.IsNullOrEmpty(location))
            {
                properties = properties.Where(p => p.Location.Contains(location)).ToList();
            }
            if (startDate.HasValue && endDate.HasValue)
            {
                properties = properties.Where(p => CheckAvailability(p, startDate.Value, endDate.Value)).ToList();
            }
            if (priceRange.HasValue)
            {
                properties = properties.Where(p => p.PricePerNight <= priceRange.Value).ToList();
            }

            var model = new HomeViewModel
            {
                FeaturedProperties = properties.Select(p => new PropertyViewModel
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.PricePerNight
                }).ToList(),
                Testimonials = GetTestimonials()
            };

            return View("Index", model);
        }

        private List<PropertyViewModel> GetFeaturedProperties()
        {
            // Example data
            return new List<PropertyViewModel>
            {
                new PropertyViewModel
                {
                    Id = "1",
                    Name = "Beachside Villa",
                    Description = "A beautiful villa by the beach.",
                    ImageUrl = "https://www.costas-casas.com/db/huizen/2039/14409202jpg",
                    Price = 200
                },
                new PropertyViewModel
                {
                    Id = "2",
                    Name = "Mountain Cabin",
                    Description = "Cozy cabin in the mountains.",
                    ImageUrl = "https://pictures.escapia.com/HEACAB/244444/7002830926.JPEG",
                    Price = 150
                }
            };
        }

        private List<TestimonialViewModel> GetTestimonials()
        {
            // Example data
            return new List<TestimonialViewModel>
            {
                new TestimonialViewModel
                {
                    UserName = "John Doe",
                    Comment = "This site is amazing! Found the perfect place for my vacation."
                },
                new TestimonialViewModel
                {
                    UserName = "Jane Smith",
                    Comment = "Easy to use and great selection of properties."
                }
            };
        }

        private bool CheckAvailability(Property property, DateTime startDate, DateTime endDate)
        {
            // Implement logic to check if the property is available
            return true;
        }
    }
}
