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

        Task AddDeviceAsync(AddDeviceInputModel inputModel);

        Task<DeviceDescriptionViewModel> DeviceDescriptionByIdAsync(Guid id);

        Task<EditDeviceViewModel> GetDeviceEditById(Guid id);

        Task<bool> EditDeviceAsync(EditDeviceViewModel model);
    }
}
