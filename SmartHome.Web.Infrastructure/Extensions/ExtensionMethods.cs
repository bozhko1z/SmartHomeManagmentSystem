
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Data;


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
    }
}
