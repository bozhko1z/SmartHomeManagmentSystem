using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Configuration
{
    public static class DbSeeder
    {
        public static void SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            string[] roles = { "Admin", "Manager", "User" };

            foreach (var role in roles)
            {
                var roleExist = roleManager.RoleExistsAsync(role).GetAwaiter().GetResult();
                if (!roleExist)
                {
                    var result = roleManager.CreateAsync(new IdentityRole<Guid> { Name = role }).GetAwaiter().GetResult();
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Failed to create role: {role}");
                    }
                }
            }
        }

        public static void AssignAdminRole(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string adminEmail = "adminBojko@abv.bg";
            string adminPassword = "admin123";
        }
    }
}
