using Microsoft.AspNetCore.Mvc;
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
