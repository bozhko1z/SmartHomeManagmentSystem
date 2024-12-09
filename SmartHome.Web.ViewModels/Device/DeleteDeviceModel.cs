using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Web.ViewModels.Device
{
    public class DeleteDeviceModel
    {
        public string Id { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public string DeviceType { get; set; } = null!;

        public bool Status { get; set; }
    }
}
