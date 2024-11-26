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
    }
}
