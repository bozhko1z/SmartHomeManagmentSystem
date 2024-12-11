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
                cfg.CreateMap<Device, DeviceDescriptionViewModel>();
                // Add this mapping for AddDeviceInputModel to Device
                cfg.CreateMap<AddDeviceInputModel, Device>()
                    .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.DeviceType))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
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

        [Test]
        public async Task DeviceDescriptionByIdAsync_ShouldReturnDeviceDescription()
        {
            var deviceId = Guid.NewGuid();
            var device = new Device { Id = deviceId, DeviceName = "Test Device", Type = "Switch", Status = true };

            this.deviceRepo.Setup(d => d.GetByIdAsync(deviceId)).ReturnsAsync(device);

            var deviceService = new DeviceService(this.deviceRepo.Object);

            var result = await deviceService.DeviceDescriptionByIdAsync(deviceId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Device", result.DeviceName);
            Assert.AreEqual("Switch", result.Type);
            Assert.IsTrue(result.Status);
        }

        // Test for GetAllDevicesAsync
        [Test]
        public async Task GetAllDevicesAsync_ShouldReturnAllDevices()
        {
            var devices = new List<Device>
            {
                new Device { Id = Guid.NewGuid(), DeviceName = "Device 1", Type = "Light", Status = true },
                new Device { Id = Guid.NewGuid(), DeviceName = "Device 2", Type = "Switch", Status = false }
            };

            var mockDevices = devices.AsQueryable().BuildMock();

            this.deviceRepo.Setup(d => d.GetAllAttached()).Returns(mockDevices);

            var deviceService = new DeviceService(this.deviceRepo.Object);

            var result = await deviceService.GetAllDevicesAsync();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task AddDeviceAsync_ShouldAddDeviceSuccessfully()
        {
            var inputModel = new AddDeviceInputModel
            {
                DeviceName = "New Device",
                DeviceType = "Sensor",
                Status = true
            };

            this.deviceRepo.Setup(d => d.AddAysnc(It.IsAny<Device>())).Returns(Task.CompletedTask);

            var deviceService = new DeviceService(this.deviceRepo.Object);

            await deviceService.AddDeviceAsync(inputModel);

            this.deviceRepo.Verify(d => d.AddAysnc(It.IsAny<Device>()), Times.Once);
        }

        [Test]
        public async Task SoftDeleteDeviceAsync_ShouldReturnFalseIfDeviceNotFound()
        {
            var deviceId = Guid.NewGuid();

            // Setup an empty list to simulate no devices in the repository
            var mockDevices = Enumerable.Empty<Device>().AsQueryable().BuildMock();

            // Mock the method GetAllAttached to return the mock data
            this.deviceRepo.Setup(d => d.GetAllAttached()).Returns(mockDevices);

            var deviceService = new DeviceService(this.deviceRepo.Object);

            var result = await deviceService.SoftDeleteDeviceAsync(deviceId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task SoftDeleteDeviceAsync_ShouldReturnFalseIfHasActiveRooms()
        {
            var deviceId = Guid.NewGuid();
            var device = new Device
            {
                Id = deviceId,
                DeviceName = "Test Device",
                Type = "Switch",
                Status = false,
                DevicesRooms = new List<DeviceRoom> { new DeviceRoom { IsDeleted = false } }
            };

            var mockDevices = new List<Device> { device }.AsQueryable().BuildMock();

            this.deviceRepo.Setup(d => d.GetAllAttached()).Returns(mockDevices);

            var deviceService = new DeviceService(this.deviceRepo.Object);

            var result = await deviceService.SoftDeleteDeviceAsync(deviceId);

            Assert.IsFalse(result);
        }

    }
}