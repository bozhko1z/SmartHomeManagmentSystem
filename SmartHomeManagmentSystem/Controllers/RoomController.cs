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
        private readonly IRoomService roomService;
        public RoomController(IRoomService roomService)
        {
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await this.roomService
                .GetRoomEditByIdAsync(id);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await this.roomService.UpdateRoomAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var roomGuid))
            {
                return RedirectToAction(nameof(Index));
            }
            RoomDescriptionModel model = await this.roomService.GetRoomDetailsAsync(roomGuid);

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
            if (!Guid.TryParse(id, out var guidId))
            {
                return RedirectToAction(nameof(Index));
            }
            bool isSoftDeleted = await this.roomService.SoftDeleteRoomAsync(guidId);

            if (!isSoftDeleted)
            {
                TempData["Error Message"] = "Unable to delete room!";
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
