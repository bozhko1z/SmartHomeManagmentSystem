using Microsoft.AspNetCore.Mvc;
using SmartHomeManagmentSystem.Models;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceController : Controller
    {
        private static List<Device> devices = new List<Device>();
        public IActionResult Index()
        {
            return View(devices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Device device)
        {
            devices.Add(device);
            return RedirectToAction("Index");
        }

        
        public IActionResult Details(int id)
        {
            Device device = devices.Find(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }
    }
}
