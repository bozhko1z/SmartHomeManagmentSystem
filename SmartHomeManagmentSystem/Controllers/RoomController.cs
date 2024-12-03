using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Web.ViewModels.Room;
using SmartHome.Web.ViewModels.Device;
using SmartHome.Services.Data.Interfaces;

namespace SmartHomeManagmentSystem.Controllers
{
    public class RoomController : BaseController
    {
        private readonly SmartHomeDbContext dbContext;
        private readonly IRoomService roomService;
        public RoomController(SmartHomeDbContext dbContext, IRoomService roomService)
        {
            this.dbContext = dbContext;
            this.roomService = roomService;
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<RoomIndexViewModel> rooms = await this.roomService.GetAllRoomsAsync();


            return View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoomInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            await this.roomService.AddRoomAsync(inputModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Description(string? id)
        {
            Guid roomId = Guid.Empty;
            bool isIdValid = IsGuidIdValid(id, ref roomId);

            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Room? room = await this.dbContext
                .Rooms
                .Include(r=>r.DevicesRooms)
                .ThenInclude(d=>d.Device)
                .FirstOrDefaultAsync(r => r.Id == roomId);

            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }

            RoomDescriptionModel viewModel = new RoomDescriptionModel()
            {
                RoomName = room.RoomName,
                Devices = room.DevicesRooms
                .Where(d => d.IsDeleted == false)
                .Select(r => new RoomDeviceViewModel
                {
                    Name = r.Device.DeviceName,
                    Type = r.Device.Type.ToString(),
                    Status = r.Device.Status
                })
                .ToArray()
            };
            return View(viewModel);

        }
    }
}
