using SmartHome.Web.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.Data.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<AllDevicesViewModel>> GetAllDevicesAsync();
    }
}
