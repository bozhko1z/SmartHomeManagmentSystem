using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Models;
using SmartHome.Services.Data;
using SmartHome.Services.Data.Interfaces;
using SmartHomeManagmentSystem.Areas.Admin.ViewModels;
using SmartHomeManagmentSystem.Controllers;

namespace SmartHomeManagmentSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public UserManagementController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> UpdateRole(string userId, string role)
        {
            Guid userIdGuid = Guid.Empty;

            if (IsGuidIdValid(userId, ref userIdGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool userExists = await this.userService.UserExistsByIdAsync(userIdGuid);
            if (!userExists)
            {
                return RedirectToAction(nameof(Index));
            }
            bool asignResult = await this.userService.AssignUserToRoleAsync(userIdGuid, role);

            if (!asignResult)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            Guid userIdGuid = Guid.Empty;

            if (IsGuidIdValid(userId, ref userIdGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool userExists = await this.userService.UserExistsByIdAsync(userIdGuid);
            if (!userExists)
            {
                return RedirectToAction(nameof(Index));
            }

            bool removeResult = await this.userService.DeleteUserAsync(userIdGuid);
            if (!removeResult)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
