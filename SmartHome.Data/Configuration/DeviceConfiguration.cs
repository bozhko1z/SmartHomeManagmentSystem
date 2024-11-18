
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;
using static SmartHome.Commons.ValidationConstants.Device;

namespace SmartHome.Data.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DeviceName)
                .IsRequired()
                .HasMaxLength(DeviceMaxName);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasDefaultValue(DeviceDefaultStatus);

            builder.HasData(this.SeedDevices());
        }

        private List<Device> SeedDevices()
        {
            List<Device> devices = new List<Device>()
            {
                 new Device
                 {
                     DeviceName = "Switch 1",
                     Type = Models.Enums.DType.Switch,
                     Status = false
                 },

                 new Device
                 {
                    DeviceName = "Switch 2",
                    Type = Models.Enums.DType.Switch,
                    Status = false
                 }
            };
            return devices;
        }
    }
}
