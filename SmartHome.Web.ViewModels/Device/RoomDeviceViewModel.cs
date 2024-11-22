using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Web.ViewModels.Device
{
    public class RoomDeviceViewModel
    {
        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;

        public bool Status { get; set; }
    }
}
