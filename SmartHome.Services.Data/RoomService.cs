using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
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
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room, Guid> roomRepository;
        public RoomService(IRepository<Room, Guid> roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task AddRoomAsync(AddRoomInputModel model)
        {
            Room room = new Room();

            AutoMapperConfig.MapperInstance.Map(model, room);

            await this.roomRepository.AddAysnc(room);
        }

        public async Task<IEnumerable<RoomIndexViewModel>> GetAllRoomsAsync()
        {
            IEnumerable<RoomIndexViewModel> rooms = await this.roomRepository
               .GetAllAttached()
               .To<RoomIndexViewModel>()
               .ToArrayAsync();

            return rooms;
        }

        public async Task<RoomDescriptionModel> GetRoomDetailsAsync(Guid id)
        {
            Room? room = await this.roomRepository
                .GetAllAttached()
                .Include(r => r.DevicesRooms)
                .ThenInclude(d => d.Device)
                .FirstOrDefaultAsync(r => r.Id == id);
            
            RoomDescriptionModel viewModel = null;
            
            if (room != null)
            {
                viewModel = new RoomDescriptionModel()
                {
                    RoomName = room.RoomName,
                    Devices = room.DevicesRooms
                .Where(d => d.IsDeleted == false)
                .Select(r => new RoomDeviceViewModel
                {
                    Name = r.Device.DeviceName,
                    Type = r.Device.Type.ToString(),
                    Status = r.Device.Status
                })
                .ToArray()
                };
            }

            return viewModel;
        }
    }
}
