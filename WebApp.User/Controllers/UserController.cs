using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebApp.Core.Repository.Abstract;
using WebApp.Entities.Concrete;
using WebApp.User.Models;

namespace WebApp.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IRepository<Personel> _personelRepository;
#pragma warning restore IDE0052 // Remove unread private members
        public UserController(IStringLocalizer<UserController> localizer, IRepository<Personel> personelRepository)
        {
            _localizer = localizer;
            _personelRepository = personelRepository;
        }
        public IActionResult Index()
        {

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var nameSurnameValue = _localizer["NameSurname"];
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {
            return View(request);
        }
    }
}