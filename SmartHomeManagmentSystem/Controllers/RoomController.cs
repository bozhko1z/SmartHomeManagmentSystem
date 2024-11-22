using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Web.ViewModels.Room;
using SmartHome.Web.ViewModels.Device;

namespace SmartHomeManagmentSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly SmartHomeDbContext dbContext;
        public RoomController(SmartHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<RoomIndexViewModel> rooms = this.dbContext
                .Rooms
                .Select(r => new RoomIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomName = r.RoomName,
                })
                .ToArray();
            return View(rooms);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddRoomInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            Room room = new Room()
            {
                RoomName = inputModel.RoomName
            };
             dbContext.Rooms.Add(room);
             dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Description(string? id)
        {
            Guid roomId = Guid.Empty;
            bool isIdValid = IsRoomIdValid(id, ref roomId);

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


        private bool IsRoomIdValid(string? id, ref Guid roomId)
        {

            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isIdValid = Guid.TryParse(id, out roomId);
            if (!isIdValid)
            {
                return false;
            }

            return true;
        }
    }
}
