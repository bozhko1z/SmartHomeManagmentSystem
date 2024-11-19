using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string RoomName { get; set; } = null!;

        //public int DeviceId { get; set; }

        public virtual ICollection<DeviceRoom> DevicesRooms { get; set; } = new HashSet<DeviceRoom>();
    }
}
