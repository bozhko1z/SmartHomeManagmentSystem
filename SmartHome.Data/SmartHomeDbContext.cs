using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System.Reflection;


namespace SmartHome.Data
{
    public class SmartHomeDbContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
