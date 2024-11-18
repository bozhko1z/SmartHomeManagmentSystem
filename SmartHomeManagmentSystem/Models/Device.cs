using SmartHomeManagmentSystem.Enums;

namespace SmartHomeManagmentSystem.Models
{
    public class Device
    {
        public Device()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string DeviceName { get; set; } = null!;

        public DType DeviceType { get; set; }

        public bool Status { get; set; }

        public int RoomId { get; set; }

        public string UserId { get; set; } = null!;
    }
}
