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

            RoomDescriptionModel descriptionModel = await this.roomService.GetRoomDetailsAsync(roomId);

            if (descriptionModel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(descriptionModel);

        }
    }
}
