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

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly SmartHomeDbContext dbContext;
        private IRepository<Device, Guid> deviceRepo;
        public DeviceController(SmartHomeDbContext dbContext, IRepository<Device, Guid> deviceRepo)
        {
            this.dbContext = dbContext;
            this.deviceRepo = deviceRepo;
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
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddDeviceInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            ViewBag.Types = new SelectList(Types.GetAll(), "Id", "Name");

            Device device = new Device()
            {
                DeviceName = inputModel.DeviceName,
                Type = inputModel.TypeId.ToString(),
                Status = inputModel.Status,
            };

            await deviceRepo.AddAysnc(device);
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
