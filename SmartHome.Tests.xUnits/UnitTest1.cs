using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Repository;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Services.Data;
using SmartHome.Services.Mapping;
using SmartHome.Web.ViewModels.Room;
using Xunit;

public class RoomServiceTests
{
    private DbContextOptions<SmartHomeDbContext> dbContextOptions;
    private SmartHomeDbContext dbContext;
    private IRepository<Room, Guid> roomRepository;
    private RoomService roomService;

    public RoomServiceTests()
    {
        // Configure in-memory database
        this.dbContextOptions = new DbContextOptionsBuilder<SmartHomeDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        this.dbContext = new SmartHomeDbContext(this.dbContextOptions);
        this.roomRepository = new Repository<Room, Guid>(this.dbContext);
        this.roomService = new RoomService(this.roomRepository);

        // AutoMapper configuration
        AutoMapperConfig.RegisterMappings(
            typeof(AddRoomInputModel).Assembly,
            typeof(Room).Assembly);
    }

    [Fact]
    public async Task AddRoomAsync_ShouldAddRoomSuccessfully()
    {
        var model = new AddRoomInputModel { RoomName = "Living Room" };

        await this.roomService.AddRoomAsync(model);

        var room = await this.dbContext.Rooms.FirstOrDefaultAsync();
        Assert.NotNull(room);
        Assert.Equal("Living Room", room.RoomName);
    }

    [Fact]
    public async Task GetAllRoomsAsync_ShouldReturnAllRooms()
    {
        this.dbContext.Rooms.Add(new Room { RoomName = "Living Room" });
        this.dbContext.Rooms.Add(new Room { RoomName = "Bedroom" });
        await this.dbContext.SaveChangesAsync();

        var rooms = await this.roomService.GetAllRoomsAsync();

        Assert.Equal(2, rooms.Count());
        Assert.Contains(rooms, r => r.RoomName == "Living Room");
        Assert.Contains(rooms, r => r.RoomName == "Bedroom");
    }

    [Fact]
    public async Task GetRoomDetailsAsync_ShouldReturnRoomDetails()
    {
        var roomId = Guid.NewGuid();
        var room = new Room
        {
            Id = roomId,
            RoomName = "Kitchen",
            DevicesRooms = new List<DeviceRoom> { new DeviceRoom { IsDeleted = false, Device = new Device { DeviceName = "Fridge" } } }
        };

        this.dbContext.Rooms.Add(room);
        await this.dbContext.SaveChangesAsync();

        var result = await this.roomService.GetRoomDetailsAsync(roomId);

        Assert.NotNull(result);
        Assert.Equal("Kitchen", result.RoomName);
        Assert.Single(result.Devices);
        Assert.Equal("Kitchen", result.Devices.First().Name);
    }

    [Fact]
    public async Task GetRoomEditByIdAsync_ShouldReturnEditModel()
    {
        var roomId = Guid.NewGuid();
        this.dbContext.Rooms.Add(new Room { Id = roomId, RoomName = "Bathroom" });
        await this.dbContext.SaveChangesAsync();

        var result = await this.roomService.GetRoomEditByIdAsync(roomId);

        Assert.NotNull(result);
        Assert.Equal("Bathroom", result.RoomName);
    }

    [Fact]
    public async Task SoftDeleteRoomAsync_ShouldDeleteRoomWhenNoActiveDevices()
    {
        var roomId = Guid.NewGuid();
        this.dbContext.Rooms.Add(new Room { Id = roomId, RoomName = "Study" });
        await this.dbContext.SaveChangesAsync();

        var result = await this.roomService.SoftDeleteRoomAsync(roomId);

        var room = await this.dbContext.Rooms.FindAsync(roomId);

        Assert.True(result);
        Assert.True(room.IsDeleted);
    }

    [Fact]
    public async Task SoftDeleteRoomAsync_ShouldNotDeleteRoomWithActiveDevices()
    {
        var roomId = Guid.NewGuid();
        this.dbContext.Rooms.Add(new Room
        {
            Id = roomId,
            RoomName = "Office",
            DevicesRooms = new List<DeviceRoom> { new DeviceRoom { IsDeleted = false } }
        });
        await this.dbContext.SaveChangesAsync();

        var result = await this.roomService.SoftDeleteRoomAsync(roomId);

        Assert.False(result);
    }

    [Fact]
    public async Task UpdateRoomAsync_ShouldUpdateRoomSuccessfully()
    {
        var roomId = Guid.NewGuid();
        this.dbContext.Rooms.Add(new Room { Id = roomId, RoomName = "Guest Room" });
        await this.dbContext.SaveChangesAsync();

        var model = new EditRoomViewModel { Id = roomId.ToString(), RoomName = "Guest Bedroom" };
        var result = await this.roomService.UpdateRoomAsync(model);

        var room = await this.dbContext.Rooms.FindAsync(roomId);

        Assert.True(result);
        Assert.Equal("Guest Bedroom", room.RoomName);
    }

    [Fact]
    public async Task UpdateRoomAsync_ShouldReturnFalseIfRoomNotFound()
    {
        var model = new EditRoomViewModel { Id = Guid.NewGuid().ToString(), RoomName = "Nonexistent Room" };

        var result = await this.roomService.UpdateRoomAsync(model);

        Assert.False(result);
    }
}
