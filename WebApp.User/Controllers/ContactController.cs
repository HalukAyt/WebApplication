using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace WebApp.User.Controllers
{
    public class ContactController : Controller
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private IStringLocalizer<SharedResource> _localizer;
#pragma warning restore IDE0044 // Add readonly modifier
        public ContactController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var welcome_value = _localizer["Welcome"];
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            return View();
        }
    
    }
}