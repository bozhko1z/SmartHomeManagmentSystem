using SmartHome.Data.Models;
using SmartHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Web.ViewModels.Device
{
    using Data.Models;
    public class EditDeviceViewModel
    {
        public string Id { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public string DeviceType { get; set; }

        public bool Status { get; set; }
    }
}
