using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Models
{
    public class DeviceRoom
    {
        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; } = null!;

        public Guid DeviceId { get; set; }

        public virtual Device Device { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
