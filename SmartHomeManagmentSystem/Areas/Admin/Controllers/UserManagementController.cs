using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Models;
using SmartHomeManagmentSystem.Areas.Admin.ViewModels;

namespace SmartHomeManagmentSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserManagementController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = this.userManager.Users.ToList();
            var userViewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                userViewModel.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = roles.ToList()
                });
            }
            return View(userViewModel);
        }
    }
}
