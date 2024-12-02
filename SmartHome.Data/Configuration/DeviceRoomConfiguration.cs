using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Configuration
{
    public class DeviceRoomConfiguration : IEntityTypeConfiguration<DeviceRoom>
    {
        public void Configure(EntityTypeBuilder<DeviceRoom> builder)
        {
            builder.HasKey(pk => new
            {
                pk.DeviceId, pk.RoomId
            });

            builder.Property(d => d.IsDeleted).HasDefaultValue(false);

            builder.HasOne(dr => dr.Device)
                .WithMany(d => d.DevicesRooms)
                .HasForeignKey(m => m.DeviceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dr => dr.Room)
                .WithMany(d => d.DevicesRooms)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
