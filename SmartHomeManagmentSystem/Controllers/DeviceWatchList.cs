using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Web.ViewModels.DeviceWatchList;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceWatchList : BaseController
    {
        private readonly SmartHomeDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public DeviceWatchList(SmartHomeDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            string? userId = this.userManager.GetUserId(User);
            if (String.IsNullOrEmpty(userId))
            {
                return RedirectToPage("Login");
            }
            


            return View();
        }
    }
}
