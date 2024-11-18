using Microsoft.AspNetCore.Mvc;
using SmartHomeManagmentSystem.Models;
using System.Diagnostics;

namespace SmartHomeManagmentSystem.Controllers
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
            ViewBag.Message = "Welcome to the world of Smart Devices";
            return View();
        }
    }
}
