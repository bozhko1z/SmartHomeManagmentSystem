using SmartHome.Data.Models.Enums;

namespace SmartHome.Data.Models
{
    public class Device
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string DeviceName { get; set; } = null!;

        public DType Type { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<DeviceRoom> DevicesRooms { get; set; } = new HashSet<DeviceRoom>();

        //public int RoomId { get; set; }

        //public string UserId { get; set; } = null!;
    }
}
