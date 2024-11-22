
using SmartHome.Web.ViewModels.Room;
using System.ComponentModel.DataAnnotations;
using static SmartHome.Commons.ValidationConstants.Device;

namespace SmartHome.Web.ViewModels.Device
{
    public class AddDeviceToRoomInputModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(DeviceMaxName)]
        public string DeviceName { get; set; } = null!;

        public IEnumerable<RoomCheckItemViewModel> Rooms { get; set; } = new HashSet<RoomCheckItemViewModel>();
    }
}
