using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Models.Enums;
using SmartHome.Web.ViewModels.Device;
using SmartHomeManagmentSystem.Models;
using Device = SmartHome.Data.Models.Device;
using SmartHome.Web.ViewModels.Room;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly SmartHomeDbContext dbContext;
        public DeviceController(SmartHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Device> allDevices = await this.dbContext
                .Devices
                .ToArrayAsync();

            return View(allDevices);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
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
        public async Task<IActionResult> Add(AddDeviceInputModel inputModel)
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

            await dbContext.Devices.AddAsync(device);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Description(string id) 
        {
            Guid guidId = Guid.Empty;
            bool isGuidValid = this.IsGuidIdValid(id, ref guidId);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }
            Device? device = await dbContext.Devices
                .FirstOrDefaultAsync(d => d.Id == guidId);

            if (device == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(device);
        }


        [HttpGet]
        public async Task<IActionResult> AddToRoom(string? id)
        {
            Guid devId = Guid.Empty;
            bool isGuidValid = IsGuidIdValid(id, ref devId);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Device? device = await dbContext
                .Devices
                .FirstOrDefaultAsync(d => d.Id == devId);

            if (device == null)
            {
                return RedirectToAction(nameof(Index));
            }

            AddDeviceToRoomInputModel model = new AddDeviceToRoomInputModel()
            {
                Id = id,
                DeviceName = device.DeviceName,
                Rooms = await dbContext
                .Rooms
                .Include(d => d.DevicesRooms)
                .ThenInclude(dr => dr.Device)
                .Select(r => new RoomCheckItemViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomName = r.RoomName,
                    IsSelected = r.DevicesRooms.Any(dr => dr.Device.Id == devId)
                })
                .ToArrayAsync()
            };
            return View(model);
        }










        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
