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
        public IActionResult Edit(AddRoomInputModel inputModel)
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
    }
}
