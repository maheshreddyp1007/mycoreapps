using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Login()
        {

            var myclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "test"),
                new Claim(ClaimTypes.Email, "test@test.com")
            };

            var myIdentity = new ClaimsIdentity(myclaims, CookieAuthenticationDefaults.AuthenticationScheme);

            var myPrincipal = new ClaimsPrincipal(myIdentity);

            await HttpContext.SignInAsync(
    CookieAuthenticationDefaults.AuthenticationScheme,
    myPrincipal);


            return RedirectToAction("Create","GroceryItems");
        }
    }
}
