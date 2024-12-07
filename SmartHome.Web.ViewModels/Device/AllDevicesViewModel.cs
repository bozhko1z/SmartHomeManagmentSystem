using SmartHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Web.ViewModels.Device
{
    using Data.Models;
    public class AllDevicesViewModel : IMapFrom<Device>
    {
        public string Id { get; set; } = null!;
        public string DeviceName { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool Status { get; set; }
    }
}
