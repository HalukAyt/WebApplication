using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApp.Business.Abstract;
using WebApp.Entities.Concrete;
using WebApp.Models.ViewModels.Personels;

namespace CarPark.User.Controllers
{
    [Authorize(Roles = "admin")]
    public class PersonelsController : Controller
    {
        private readonly IPersonelService _personelService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly UserManager<Personel> _userManager;
        private readonly IWebHostEnvironment _env;

#pragma warning disable IDE0290 // Use primary constructor
        public PersonelsController(IPersonelService personelService,
#pragma warning restore IDE0290 // Use primary constructor
            IMapper mapper,
            IWebHostEnvironment env,
            ICityService cityService,
            UserManager<Personel> userManager)
        {
            _personelService = personelService;
            _userManager = userManager;
            _cityService = cityService;
            _mapper = mapper;
            _env = env;
        }
        public IActionResult GetPersonelsByAge()
        {
            var result = _personelService.GetPersonelsByAge();

            return View(result);
        }
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            var cities = await _cityService.GetAllCitiesAsync();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            user.ImageUrl = $"/Media/Personels/{user.ImageUrl}";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var personelInfo = _mapper.Map<PersonelProfileInfo>(user);
            personelInfo.Cities = cities.Result;
            return View(personelInfo);
        }
        [HttpPost]
        public async Task<IActionResult> Settings(PersonelProfileInfo personelInfo)
        {
            var user = _userManager.GetUserAsync(User).Result;
            string imgUrl = "";
            if (personelInfo.Image != null && personelInfo.Image.Length > 0)
            {
                var path = Path.Combine(_env.WebRootPath, "Media/Personels/");
                var fileName = Guid.NewGuid().ToString() + "_" + personelInfo.Image.FileName;

                var filePath = Path.Combine(path, fileName);

#pragma warning disable IDE0063 // Use simple 'using' statement
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    personelInfo.Image.CopyTo(fileStream);
                    imgUrl = fileName;
                }
#pragma warning restore IDE0063 // Use simple 'using' statement
            }
            else
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                imgUrl = user.ImageUrl;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            personelInfo.UserName = user.UserName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            personelInfo.Email = user.Email;
            personelInfo.ImageUrl = imgUrl;

            var personel = _mapper.Map(personelInfo, user);
            var updated = await _userManager.UpdateAsync(personel);
            if (updated.Succeeded)
#pragma warning disable IDE0037 // Use inferred member name
                return Json(new { message = "Başarılı", success = true, personel = personel });
#pragma warning restore IDE0037 // Use inferred member name
            else
#pragma warning disable IDE0037 // Use inferred member name
                return Json(new { message = "Başarısız", success = false, personel = personel });
#pragma warning restore IDE0037 // Use inferred member name
        }
    }
}