using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHomeManagmentSystem.Models;
using Device = SmartHome.Data.Models.Device;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceController : Controller
    {
        private readonly SmartHomeDbContext dbContext;
        public DeviceController(SmartHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Device> allDevices = this.dbContext.Devices.ToList();
            return View(allDevices);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Device device)
        {
            dbContext.Devices.Add(device);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Description(string id) 
        {
            bool IsValidId = Guid.TryParse(id, out Guid guidId);

            if (!IsValidId)
            {
                return RedirectToAction(nameof(Index));
            }
            Device? device = dbContext.Devices
                .FirstOrDefault(d => d.Id == guidId);

            if (device == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(device);
        }
    }
}
