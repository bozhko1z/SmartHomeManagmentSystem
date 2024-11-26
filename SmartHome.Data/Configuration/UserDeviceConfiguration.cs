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
    public class UserDeviceConfiguration : IEntityTypeConfiguration<UserDevice>
    {
        public void Configure(EntityTypeBuilder<UserDevice> builder)
        {
            builder.HasKey(ud => new
            {
                ud.UserId,ud.DeviceId
            });

            builder.HasOne(d => d.Device)
                .WithMany(ud => ud.DeviceUsers)
                .HasForeignKey(ud => ud.DeviceId);

            builder.HasOne(u => u.ApplicationUser)
                .WithMany(d => d.UserDevices)
                .HasForeignKey(u => u.UserId);
        }
    }
}
