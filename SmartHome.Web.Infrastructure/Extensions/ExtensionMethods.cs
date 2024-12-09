
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Data;
using SmartHome.Data.Models;


namespace SmartHome.Web.Infrastructure.Extensions
{
    public static class ExtensionMethods
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            SmartHomeDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<SmartHomeDbContext>();
            dbContext.Database.Migrate();
            
            return app;
        }


        public async static Task<IApplicationBuilder> SeedAdministartor(this IApplicationBuilder app, string email, string password)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            RoleManager<IdentityRole<Guid>>? roleManager = serviceProvider
                 .GetService<RoleManager<IdentityRole<Guid>>>();

            IUserStore<ApplicationUser>? userStore = serviceProvider
                .GetService<IUserStore<ApplicationUser>>();
            UserManager<ApplicationUser>? userManager = serviceProvider
                .GetService<UserManager<ApplicationUser>>();

            if (roleManager == null)
            {
                throw new ArgumentNullException("Service cannot be obtained!");
            }

            if (userStore == null)
            {
                throw new ArgumentNullException("Service cannot be obtained");
            }

            if (userManager == null)
            {
                throw new ArgumentNullException("Service cannot be obtained");
            }

            bool roleExists = await roleManager.RoleExistsAsync("Admin");

            IdentityRole<Guid>? adminRole = null;

            if (!roleExists)
            {
                adminRole = new IdentityRole<Guid>("Admin");

                IdentityResult result = await roleManager.CreateAsync(adminRole);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Error occured while creating the admin role!");
                }
            }
            else
            {
                adminRole = await roleManager.FindByNameAsync("Admin");
            }

            

            ApplicationUser? adminUser = await userManager.FindByEmailAsync(email);
            if (adminUser == null)
            {
                adminUser = await CreateAdmin(email, password, userStore, userManager);
            }
            userManager.AddToRoleAsync(adminUser, "Admin");

            return app;

        }

        private static async Task<ApplicationUser> CreateAdmin(string email, string password, 
            IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                Email = email,
            };

            await userStore.SetUserNameAsync(applicationUser, email, CancellationToken.None);
            IdentityResult result = await userManager.CreateAsync(applicationUser, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Error occured while registring Admin");
            }
            return applicationUser;
        }
    }
}
