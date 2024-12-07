using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using SmartHome.Data.Models.Enums;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Services.Data.Interfaces;
using SmartHome.Services.Mapping;
using SmartHome.Web.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.Data
{
    public class DeviceService : IDeviceService
    {
        private IRepository<Device, Guid> devRepository;

        public DeviceService(IRepository<Device, Guid> devRepository)
        {
            this.devRepository = devRepository;
        }

        public async Task AddDeviceAsync(AddDeviceInputModel inputModel)
        {
            Device device = new Device();
            AutoMapperConfig.MapperInstance.Map(inputModel, device);
            

            await dbContext.AddAsync(device);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IEnumerable<AllDevicesViewModel>> GetAllDevicesAsync()
        {
            return await this.devRepository
                .GetAllAttached()
                .To<AllDevicesViewModel>()
                .ToArrayAsync();
        }
    }
}
