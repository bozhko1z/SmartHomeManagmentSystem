using SmartHome.Web.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Web.ViewModels.Room
{
    public class RoomDescriptionModel
    {
        public string RoomName { get; set; } = null!;

        public IEnumerable<RoomDeviceViewModel> Devices { get; set; } = new HashSet<RoomDeviceViewModel>();
    }
}
