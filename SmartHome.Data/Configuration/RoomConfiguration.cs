using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;
using static SmartHome.Commons.ValidationConstants.Room;

namespace SmartHome.Data.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(p => p.RoomName)
                .IsRequired()
                .HasMaxLength(RoomMaxName);

            builder.HasData(this.SeedRooms());
        }
        private IEnumerable<Room> SeedRooms()
        {
            IEnumerable<Room> rooms = new List<Room>()
            {
                new Room()
                {
                    RoomName = "Kitchen"
                },
                new Room()
                {
                    RoomName = "Living Room"
                },
                new Room()
                {
                    RoomName = "Bathroom"
                }
                
            };
            return rooms;
        }
    }
}
