using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Web.ViewModels.DeviceWatchList;

namespace SmartHomeManagmentSystem.Controllers
{
    [Authorize]
    public class DeviceWatchList : BaseController
    {
        private readonly SmartHomeDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public DeviceWatchList(SmartHomeDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = this.userManager.GetUserId(User)!;
            
            IEnumerable<UserWatchListViewModel> deviceWatchList = await this.dbContext
                .UsersDevices
                .Where(ud => ud.UserId.ToString().ToLower() == userId.ToLower())
                .Select(ud => new UserWatchListViewModel()
                {
                    DeviceId = ud.DeviceId.ToString(),
                    DeviceName = ud.Device.DeviceName,
                    Type = ud.Device.Type.ToString(),
                    Status = ud.Device.Status
                })
                .ToListAsync();

            return View(deviceWatchList);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchList(string deviceId)
        {
            Guid deviceGuid = Guid.Empty;
            if (!IsGuidIdValid(deviceId, ref deviceGuid))
            {
                return RedirectToAction("Index", "Device");                
            }

            Device? device = await dbContext.Devices
                .FirstOrDefaultAsync(d => d.Id == deviceGuid);

            if (device == null)
            {
                return RedirectToAction("Index", "Device");
            }

            Guid userGuid = Guid.Parse(userManager.GetUserId(User)!);

            bool alreadyAddedToList = await dbContext
                .UsersDevices
                .AnyAsync(u => u.UserId == userGuid && u.DeviceId == deviceGuid);

            if (!alreadyAddedToList)
            {
                UserDevice newUserDevice = new UserDevice()
                {
                    UserId = userGuid,
                    DeviceId = deviceGuid
                };
                await dbContext.UsersDevices.AddAsync(newUserDevice);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
