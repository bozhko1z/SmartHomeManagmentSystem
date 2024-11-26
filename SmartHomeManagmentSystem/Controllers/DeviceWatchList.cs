using Microsoft.AspNetCore.Mvc;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceWatchList : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
