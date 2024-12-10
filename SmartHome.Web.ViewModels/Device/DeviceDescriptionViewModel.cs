using SmartHome.Services.Mapping;

namespace SmartHome.Web.ViewModels.Device
{
    using Data.Models;
    public class DeviceDescriptionViewModel : IMapFrom<Device>
    {
        public Guid Id { get; set; } 
        public string DeviceName { get; set; } = null!;

        public string Type { get; set; } = null!;

        public bool Status { get; set; }
    }
}
