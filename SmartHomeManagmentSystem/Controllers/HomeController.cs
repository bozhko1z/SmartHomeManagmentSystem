using Microsoft.AspNetCore.Mvc;

using System.Buffers.Text;
using System.Diagnostics;

namespace SmartHomeManagmentSystem.Controllers
{
    public class HomeController : BaseController
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

        [Route("Home/TriggerError")]
        public IActionResult TriggerError()
        {
            throw new Exception("for 500");
        }

        public IActionResult CheckEnvironment()
        {
            return Content($"Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
        }

    }
}
