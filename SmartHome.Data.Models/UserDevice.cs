using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Models
{
    public class UserDevice
    {
        public Guid UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid DeviceId { get; set; }

        public virtual Device Device { get; set; } = null!;
    }
}
