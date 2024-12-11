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
using SmartHome.Web.ViewModels.Room;

namespace SmartHome.TestServices
{
    [TestFixture]
    public class Tests2
    {
        private IEnumerable<Room> roomData = new List<Room>()
        {
            new Room
            {
                Id = Guid.Parse("ddcb8651-7a50-4b78-9119-1bdb687f985a"),
                RoomName = "Bedroom 2"
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
                cfg.CreateMap<Room, RoomIndexViewModel>();
                cfg.CreateMap<AddRoomInputModel, Room>();
                cfg.CreateMap<Room, EditRoomViewModel>();
            }).CreateMapper();
        }

        [Test]
        public async Task AddRoomAsync_ShouldAddRoom()
        {
            // Arrange
            var roomService = new RoomService(this.roomRepo.Object);

            var model = new AddRoomInputModel
            {
                RoomName = "Living Room"
            };

            // Mock the AddAsync method
            this.roomRepo.Setup(r => r.AddAysnc(It.IsAny<Room>())).Returns(Task.CompletedTask);

            // Act
            await roomService.AddRoomAsync(model);

            // Assert
            this.roomRepo.Verify(r => r.AddAysnc(It.Is<Room>(room => room.RoomName == "Living Room")), Times.Once);
        }

        [Test]
        public async Task GetAllRoomsAsync_ShouldReturnRooms()
        {
            // Arrange
            var roomService = new RoomService(this.roomRepo.Object);

            // Mock GetAllAttached to return a list of rooms
            this.roomRepo.Setup(r => r.GetAllAttached()).Returns(roomData.AsQueryable().BuildMock());

            // Act
            var result = await roomService.GetAllRoomsAsync();

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Bedroom 2", result.First().RoomName);
        }

        [Test]
        public async Task GetRoomDetailsAsync_ShouldReturnRoomDetails()
        {
            // Arrange
            var roomService = new RoomService(this.roomRepo.Object);

            var roomId = Guid.Parse("ddcb8651-7a50-4b78-9119-1bdb687f985a");

            // Mock room with DeviceRooms
            var room = new Room
            {
                Id = roomId,
                RoomName = "Bedroom 2",
                DevicesRooms = new List<DeviceRoom>
        {
            new DeviceRoom { Device = new Device { DeviceName = "Fan" }, IsDeleted = false, Room = new Room { RoomName = "Bedroom 2" } },
            new DeviceRoom { Device = new Device { DeviceName = "Light" }, IsDeleted = false, Room = new Room { RoomName = "Bedroom 2" } }
        }
            };

            // Mock repository call
            this.roomRepo.Setup(r => r.GetAllAttached())
                .Returns(new List<Room> { room }.AsQueryable().BuildMock());

            // Act
            var result = await roomService.GetRoomDetailsAsync(roomId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Bedroom 2", result.RoomName);
            Assert.AreEqual(2, result.Devices.Count());
        }

        [Test]
        public async Task GetRoomEditByIdAsync_ShouldReturnRoomForEditing()
        {
            // Arrange
            var roomService = new RoomService(this.roomRepo.Object);
            var roomId = Guid.Parse("ddcb8651-7a50-4b78-9119-1bdb687f985a");

            var room = new Room
            {
                Id = roomId,
                RoomName = "Bedroom 2"
            };

            this.roomRepo.Setup(r => r.GetAllAttached())
                .Returns(new List<Room> { room }.AsQueryable().BuildMock());

            // Act
            var result = await roomService.GetRoomEditByIdAsync(roomId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Bedroom 2", result.RoomName);
        }


        [Test]
        public async Task SoftDeleteRoomAsync_ShouldReturnFalseIfRoomHasActiveDevices()
        {
            // Arrange
            var roomService = new RoomService(this.roomRepo.Object);
            var roomId = Guid.Parse("ddcb8651-7a50-4b78-9119-1bdb687f985a");

            var room = new Room
            {
                Id = roomId,
                RoomName = "Bedroom 2",
                DevicesRooms = new List<DeviceRoom>
                {
                    new DeviceRoom { Device = new Device { DeviceName = "Fan" }, IsDeleted = false }
                }
            };

            this.roomRepo.Setup(r => r.GetAllAttached())
                .Returns(new List<Room> { room }.AsQueryable().BuildMock());

            // Act
            var result = await roomService.SoftDeleteRoomAsync(roomId);

            // Assert
            Assert.IsFalse(result);  // Cannot delete if there are active devices
        }

        [Test]
        public async Task UpdateRoomAsync_ShouldUpdateRoom()
        {
            // Arrange
            var roomService = new RoomService(this.roomRepo.Object);
            var roomId = Guid.Parse("ddcb8651-7a50-4b78-9119-1bdb687f985a");

            var model = new EditRoomViewModel
            {
                Id = roomId.ToString(),
                RoomName = "Updated Bedroom"
            };

            var room = new Room
            {
                Id = roomId,
                RoomName = "Bedroom 2"
            };

            this.roomRepo.Setup(r => r.GetAllAttached())
                .Returns(new List<Room> { room }.AsQueryable().BuildMock());

            this.roomRepo.Setup(r => r.UpdateAysnc(It.IsAny<Room>())).Returns(Task.FromResult(true));

            // Act
            var result = await roomService.UpdateRoomAsync(model);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Updated Bedroom", room.RoomName);
        }
    }
}