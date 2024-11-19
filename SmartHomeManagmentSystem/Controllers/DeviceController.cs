using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Models.Enums;
using SmartHome.Web.ViewModels.Device;
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
            ViewBag.DType = Enum.GetValues(typeof(DType))
                               .Cast<DType>()
                               .Select(dt => new SelectListItem
                               {
                                   Value = dt.ToString(),
                                   Text = dt.ToString()
                               })
                               .ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Add(AddDeviceInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            ViewBag.DType = Enum.GetValues(typeof(DType))
                               .Cast<DType>()
                               .Select(dt => new SelectListItem
                               {
                                   Value = dt.ToString(),
                                   Text = dt.ToString()
                               })
                               .ToList();

            Device device = new Device()
            {
                DeviceName = inputModel.DeviceName,
                Type = inputModel.Type,
                Status = inputModel.Status,
            };

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
