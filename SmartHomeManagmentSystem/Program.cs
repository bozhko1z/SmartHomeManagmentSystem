using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Data.Repository;
using SmartHome.Services.Mapping;
using SmartHome.Web.Infrastructure.Extensions;
using SmartHome.Web.ViewModels;
using SmartHome.Services.Data.Interfaces;
using SmartHome.Services.Data;
using SmartHome.Data.Configuration;
namespace SmartHomeManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SqlServer")!;
            string adminEmail = builder.Configuration.GetValue<string>("Administrator:Email")!;
            string adminPassword = builder.Configuration.GetValue<string>("Administrator:Password")!;

            // Add services to the container.
            builder.Services.AddDbContext<SmartHomeDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SmartHomeDbContext>();

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(cfg =>
                {
                    ConfigureIdentity(builder, cfg);
                })
                .AddEntityFrameworkStores<SmartHomeDbContext>()
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/Identity/Account/Login";
            });

            builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddServices(typeof(IDeviceService).Assembly);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            WebApplication app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DbSeeder.SeedRoles(services);
                DbSeeder.AssignAdminRole(services);
            }

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.Use((context, next) =>
            {
                if (context.User.Identity?.IsAuthenticated == true && context.Request.Path == "/")
                {
                    if (context.User.IsInRole("Admin"))
                    {
                        context.Response.Redirect("Admin/Home/Index");
                        return Task.CompletedTask;
                    }
                }
                return next();
            });

            app.UseAuthorization();

            app.SeedAdministartor(adminEmail, adminPassword);

            app.MapControllerRoute(
                name: "Areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.ApplyMigrations();
            app.Run();
        }

        private static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions cfg)
        {
            cfg.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
            cfg.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            cfg.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            cfg.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
            cfg.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            cfg.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");

            cfg.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");
            cfg.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
            cfg.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

            cfg.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }

        
    }
}
