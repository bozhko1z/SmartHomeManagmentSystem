using Moq;
using SmartHome.Data.Models;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Services.Data;
using SmartHome.Web.ViewModels.Room;
using Xunit;
public class RoomServiceTests
{
    private readonly Mock<IRepository<Room, Guid>> roomRepositoryMock;
    private readonly RoomService roomService;

    public RoomServiceTests()
    {
        roomRepositoryMock = new Mock<IRepository<Room, Guid>>();
        roomService = new RoomService(roomRepositoryMock.Object);
    }

    [Fact]
    public async Task AddRoomAsync_ShouldAddRoomToRepository()
    {
        // Arrange
        var model = new AddRoomInputModel { RoomName = "Living Room" };
        roomRepositoryMock.Setup(repo => repo.AddAysnc(It.IsAny<Room>()))
                          .Returns(Task.CompletedTask)
                          .Verifiable();

        // Act
        await roomService.AddRoomAsync(model);

        // Assert
        roomRepositoryMock.Verify(repo => repo.AddAysnc(It.Is<Room>(r => r.RoomName == model.RoomName)), Times.Once);
    }

    [Fact]
    public async Task GetAllRoomsAsync_ShouldReturnRoomIndexViewModels()
    {
        // Arrange
        var rooms = new List<Room>
        {
            new Room { Id = Guid.NewGuid(), RoomName = "Living Room" },
            new Room { Id = Guid.NewGuid(), RoomName = "Bedroom" }
        }.AsQueryable();

        roomRepositoryMock.Setup(repo => repo.GetAllAttached())
                          .Returns(rooms);

        // Act
        var result = await roomService.GetAllRoomsAsync();

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetRoomDetailsAsync_ShouldReturnRoomDetailsModel_WhenRoomExists()
    {
        // Arrange
        var roomId = Guid.NewGuid();
        var room = new Room
        {
            Id = roomId,
            RoomName = "Living Room",
            DevicesRooms = new List<DeviceRoom>
            {
                new DeviceRoom
                {
                    IsDeleted = false,
                    Room = new Room { RoomName = "Living Room" }
                }
            }
        };

        roomRepositoryMock.Setup(repo => repo.GetAllAttached())
                          .Returns(new List<Room> { room }.AsQueryable());

        // Act
        var result = await roomService.GetRoomDetailsAsync(roomId);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal("Living Room", result.RoomName);
        Xunit.Assert.Single(result.Devices);
    }

    [Fact]
    public async Task SoftDeleteRoomAsync_ShouldReturnTrue_WhenRoomIsDeleted()
    {
        // Arrange
        var roomId = Guid.NewGuid();
        var room = new Room
        {
            Id = roomId,
            DevicesRooms = new List<DeviceRoom>()
        };

        roomRepositoryMock.Setup(repo => repo.GetAllAttached())
                          .Returns(new List<Room> { room }.AsQueryable());

        roomRepositoryMock.Setup(repo => repo.UpdateAysnc(It.IsAny<Room>()))
                          .Returns(Task.FromResult(true))
                          .Verifiable();

        // Act
        var result = await roomService.SoftDeleteRoomAsync(roomId);

        // Assert
        Xunit.Assert.True(result);
        roomRepositoryMock.Verify(repo => repo.UpdateAysnc(It.Is<Room>(r => r.Id == roomId && r.IsDeleted)), Times.Once);
    }

    [Fact]
    public async Task UpdateRoomAsync_ShouldReturnTrue_WhenRoomIsUpdated()
    {
        // Arrange
        var roomId = Guid.NewGuid();
        var room = new Room { Id = roomId, RoomName = "Old Name" };

        var model = new EditRoomViewModel { Id = roomId.ToString(), RoomName = "New Name" };

        roomRepositoryMock.Setup(repo => repo.GetAllAttached())
                          .Returns(new List<Room> { room }.AsQueryable());

        roomRepositoryMock.Setup(repo => repo.UpdateAysnc(It.IsAny<Room>()))
                          .Returns(Task.FromResult(true))
                          .Verifiable();

        // Act
        var result = await roomService.UpdateRoomAsync(model);

        // Assert
        Xunit.Assert.True(result);
        roomRepositoryMock.Verify(repo => repo.UpdateAysnc(It.Is<Room>(r => r.RoomName == "New Name")), Times.Once);
    }
}
