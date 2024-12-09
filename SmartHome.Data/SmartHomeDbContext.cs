using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System.Reflection;


namespace SmartHome.Data
{
    public class SmartHomeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public SmartHomeDbContext()
        {
            
        }

        public SmartHomeDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public virtual DbSet<Device> Devices { get; set; } = null!;

        public virtual DbSet<Room> Rooms { get; set; } = null!;

        public virtual DbSet<DeviceRoom> DevicesRooms { get; set; } = null!;

        public virtual DbSet<UserDevice> UsersDevices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("Server=DESKTOP-8M32SFU;Database=SmartHomeManagmentSystem;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Room>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
