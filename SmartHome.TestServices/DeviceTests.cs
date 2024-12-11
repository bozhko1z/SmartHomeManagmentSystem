using AutoMapper;
using MockQueryable;
using Moq;
using MockQueryable.Moq;
using SmartHome.Data.Models;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Services.Data;
using SmartHome.Services.Data.Interfaces;
using SmartHome.Services.Mapping;
using SmartHome.Web.ViewModels.Device;
using Moq.EntityFrameworkCore;

namespace SmartHome.TestServices
{
    [TestFixture]
    public class Tests
    {
        private IEnumerable<Device> deviceData = new List<Device>()
        {
            new Device
            {
                Id = Guid.Parse("0e708cdf-6120-44d6-b3d2-2a51e0dc8bbe"),
                DeviceName = "Switch 1",
                Type = "Switch",
                Status = false
            }
            
        };

        private Mock<IRepository<Device, Guid>> deviceRepo;
        private Mock<IRepository<Room, Guid>> roomRepo;

        [SetUp]
        public void Setup()
        {
            this.deviceRepo = new Mock<IRepository<Device, Guid>>();
            
            this.roomRepo = new Mock<IRepository<Room, Guid>>();

            AutoMapperConfig.MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, AllDevicesViewModel>();
            }).CreateMapper();
        }

        [Test]
        public async Task EditDeviceAsync_ShouldEditDeviceSuccessfully()
        {
            var deviceId = Guid.NewGuid();
            var existingDevice = new Device { Id = deviceId, DeviceName = "Old Device", Type = "Switch", Status = false };
            var model = new EditDeviceViewModel { Id = deviceId.ToString(), DeviceName = "Updated Device", DeviceType = "Sensor", Status = true };

            var mockDevices = new List<Device> { existingDevice }.AsQueryable().BuildMock();

            this.deviceRepo.Setup(d => d.GetAllAttached()).Returns(mockDevices);
            this.deviceRepo.Setup(d => d.UpdateAysnc(It.IsAny<Device>())).Returns(Task.FromResult(true));

            var deviceService = new DeviceService(this.deviceRepo.Object);

            var result = await deviceService.EditDeviceAsync(model);

            Assert.IsTrue(result);
            Assert.AreEqual("Updated Device", existingDevice.DeviceName);
            Assert.AreEqual("Sensor", existingDevice.Type);
            Assert.IsTrue(existingDevice.Status);
        }

        [Test]
        public async Task DeviceDescriptionByIdAsync_ShouldReturnNullIfDeviceNotFound()
        {
            var deviceId = Guid.NewGuid();

            this.deviceRepo.Setup(d => d.GetByIdAsync(deviceId)).ReturnsAsync((Device?)null);

            var deviceService = new DeviceService(this.deviceRepo.Object);

            var result = await deviceService.DeviceDescriptionByIdAsync(deviceId);

            Assert.IsNull(result);
        }
    }
}