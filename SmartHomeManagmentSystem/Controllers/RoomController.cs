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
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await this.roomService
                .GetRoomDeleteById(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteModel(DeleteRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await this.roomService.DeleteRoomAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
