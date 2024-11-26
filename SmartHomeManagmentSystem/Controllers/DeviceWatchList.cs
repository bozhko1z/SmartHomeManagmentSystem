using Microsoft.AspNetCore.Mvc;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceWatchList : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
