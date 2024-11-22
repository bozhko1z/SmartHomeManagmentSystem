using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Web.ViewModels.Room;

namespace SmartHomeManagmentSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly SmartHomeDbContext dbContext;
        public RoomController(SmartHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoomIndexViewModel> rooms = await this.dbContext
                .Rooms
                .Select(r => new RoomIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomName = r.RoomName,
                })
                .ToArrayAsync();
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
            Room room = new Room()
            {
                RoomName = inputModel.RoomName
            };
            await dbContext.Rooms.AddAsync(room);
             await dbContext.SaveChangesAsync();
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
            Room? room = dbContext.Rooms
                .FirstOrDefault(d => d.Id == guidId);

            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(room);
        }
    }
}
