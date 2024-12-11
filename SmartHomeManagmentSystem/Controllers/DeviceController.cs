using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Models.Enums;
using SmartHome.Web.ViewModels.Device;

using Device = SmartHome.Data.Models.Device;
using SmartHome.Web.ViewModels.Room;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Data.Repository;
using SmartHome.Services.Data.Interfaces;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly SmartHomeDbContext dbContext;
        private readonly IDeviceService deviceService;
        public DeviceController(SmartHomeDbContext dbContext, IDeviceService deviceService)
        {
            this.dbContext = dbContext;
            this.deviceService = deviceService;
        }

        

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllDevicesViewModel> allDevices = await this.deviceService.GetAllDevicesAsync();

            return View(allDevices);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var deviceTypes = new List<Types>
            {
                new Types { Id = "Switch", Name = "Switch" },
                new Types { Id = "Light", Name = "Light" },
                new Types { Id = "Thermostat", Name = "Thermostat" }
            };

            var model = new AddDeviceInputModel
            {
                
            };

            ViewBag.DeviceTypes = new SelectList(deviceTypes, "Id", "Name");

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddDeviceInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            //if validation fails
            var deviceTypes = new List<Types>
            {
                new Types { Id = "Switch", Name = "Switch" },
                new Types { Id = "Light", Name = "Light" },
                new Types { Id = "Thermostat", Name = "Thermostat" }
            };
            ViewBag.DeviceTypes = new SelectList(deviceTypes, "Id", "Name");
            Device device = new Device()
            {
                DeviceName = inputModel.DeviceName,
                Type = inputModel.DeviceType,
                Status = inputModel.Status
            };
            await dbContext.Devices.AddAsync(device);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Device");
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
            DeviceDescriptionViewModel device = await this.deviceService
                .DeviceDescriptionByIdAsync(guidId);

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
                    IsSelected = r.DevicesRooms.Any(dr => dr.Device.Id == devId && dr.IsDeleted == false)
                })
                .ToArrayAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRoom(AddDeviceToRoomInputModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid deviceGuid = Guid.Empty;
            bool isGuidValid = IsGuidIdValid(model.Id, ref deviceGuid);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Device? device = await dbContext
                .Devices
                .FirstOrDefaultAsync(d => d.Id == deviceGuid);

            if (device == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ICollection<DeviceRoom> deviceRoomsToAdd = new List<DeviceRoom>();

            foreach (RoomCheckItemViewModel roomInputModel in model.Rooms)
            {
                Guid roomGuid = Guid.Empty;
                bool isRoomGuidValid = IsGuidIdValid(roomInputModel.Id, ref roomGuid);

                if (!isRoomGuidValid)
                {
                    ModelState.AddModelError(string.Empty, "Invalid room selection!!!");
                    return View(model);
                }
                Room? room = await dbContext
                    .Rooms
                    .FirstOrDefaultAsync(d => d.Id == roomGuid);
                if (room == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid room selection!!!");
                    return View(model);
                }
                DeviceRoom? deviceRoom = await this.dbContext.DevicesRooms
                        .FirstOrDefaultAsync(d => d.DeviceId == deviceGuid && d.RoomId == roomGuid);
                if (roomInputModel.IsSelected)
                {
                    if (deviceRoom == null)
                    {
                        deviceRoomsToAdd.Add(new DeviceRoom()
                        {
                            Room = room,
                            Device = device
                        });
                    }
                    else
                    {
                        deviceRoom.IsDeleted = false;
                    }
                }
                else
                {
                    

                    if (deviceRoom != null)
                    {
                        deviceRoom.IsDeleted = true;
                    }
                }
                this.dbContext.SaveChangesAsync();
            }
            await this.dbContext.AddRangeAsync(deviceRoomsToAdd);
            await this.dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Room");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = new EditDeviceViewModel
            {

            };
            var deviceTypes = new List<Types>
            {
                new Types { Id = "Switch", Name = "Switch" },
                new Types { Id = "Light", Name = "Light" },
                new Types { Id = "Thermostat", Name = "Thermostat" }
            };

            ViewBag.DeviceTypes = new SelectList(deviceTypes, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDeviceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var deviceTypes = new List<Types>
            {
                new Types { Id = "Switch", Name = "Switch" },
                new Types { Id = "Light", Name = "Light" },
                new Types { Id = "Thermostat", Name = "Thermostat" }
            };

            ViewBag.DeviceTypes = new SelectList(deviceTypes, "Id", "Name");
            await this.deviceService.EditDeviceAsync(model);
            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if(string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var deviceGuidId))
            {
                return RedirectToAction(nameof(Index));
            }

            DeviceDescriptionViewModel model = await this.deviceService.DeviceDescriptionByIdAsync(deviceGuidId);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpPost, ActionName("SoftDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDeleteConfirmed(string id)
        {
            if (!Guid.TryParse(id, out var deviceGuiId))
            {
                return RedirectToAction(nameof(Index));
            }

            bool isSoftDeleted = await this.deviceService.SoftDeleteDeviceAsync(deviceGuiId);

            if (!isSoftDeleted)
            {
                TempData["Error Message"] = "Unable to delete device!";
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
