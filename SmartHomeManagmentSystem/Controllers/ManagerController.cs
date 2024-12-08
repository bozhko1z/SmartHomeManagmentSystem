using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data;
using SmartHome.Services.Data.Interfaces;
using SmartHome.Web.ViewModels.Device;
using SmartHome.Web.ViewModels.Room;

namespace SmartHomeManagmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagerController : BaseController
    {
        private readonly IRoomService roomService;
        private readonly IDeviceService deviceService;

        public ManagerController(IDeviceService deviceService, IRoomService roomService)
        {
            this.deviceService = deviceService;
            this.roomService = roomService;

        }

        [HttpGet]
        public async Task<IActionResult> ManageDevices()
        {
            IEnumerable<AllDevicesViewModel> allDevices = await this.deviceService.GetAllDevicesAsync();

            return View(allDevices);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRoom()
        {
            IEnumerable<RoomIndexViewModel> rooms = await this.roomService.GetAllRoomsAsync();


            return View(rooms);
        }
    }
}
