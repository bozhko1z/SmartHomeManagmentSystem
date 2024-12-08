﻿using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using SmartHome.Data.Models.Enums;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Services.Data.Interfaces;
using SmartHome.Services.Mapping;
using SmartHome.Web.ViewModels.Device;
using SmartHome.Web.ViewModels.Room;
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


            await this.devRepository.AddAysnc(device);
        }
        public async Task<bool> EditDeviceAsync(EditDeviceViewModel model)
        {
            Device? device = await this.devRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(d => d.Id.ToString() == model.Id);

            if (device == null)
            {
                return false;
            }

            device.DeviceName = model.DeviceName;
            device.Type = model.DeviceType;
            device.Status = model.Status;
            await this.devRepository.UpdateAysnc(device);
            return true;
        }

        public async Task<DeviceDescriptionViewModel> DeviceDescriptionByIdAsync(Guid id)
        {
            Device? device = await devRepository.GetByIdAsync(id);
            DeviceDescriptionViewModel descriptionViewModel = new DeviceDescriptionViewModel();
            if (device != null)
            {
                AutoMapperConfig.MapperInstance.Map(device, descriptionViewModel);
            }
            return descriptionViewModel;
        }

        public async Task<IEnumerable<AllDevicesViewModel>> GetAllDevicesAsync()
        {
            return await this.devRepository
                .GetAllAttached()
                .To<AllDevicesViewModel>()
                .ToArrayAsync();
        }

        public async Task<EditDeviceViewModel> GetDeviceEditById(Guid id)
        {
            var device = await this.devRepository
                .GetAllAttached()
                .Where(d => d.Id == id)
                .Select(d => new EditDeviceViewModel
                {
                    DeviceName = d.DeviceName,
                    DeviceType = d.Type,
                    Status = d.Status,
                })
                .FirstOrDefaultAsync();
            return device;
        }

        public async Task<DeleteDeviceModel> DeviceDeleteByIdAsync(Guid id)
        {
            var device = await this.devRepository
                .GetAllAttached()
                .Where(r => r.Id == id)
                .Select(r => new DeleteDeviceModel
                {
                    DeviceName = r.DeviceName,
                    DeviceType = r.Type,
                    Status = r.Status,
                })
                .FirstOrDefaultAsync();
            return device;
        }

        public async Task<bool> DeleteDeviceAsync(DeleteDeviceModel model)
        {
            Device? device = await this.devRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(r => r.Id.ToString() == model.Id);

            if (device != null)
            {
                device.DeviceName = model.DeviceName;
                device.Type = model.DeviceType;
                device.Status = model.Status;
                await this.devRepository.DeleteAsync(device.Id);
            }

            return true;
        }
    }
}
