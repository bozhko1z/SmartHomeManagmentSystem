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

        public async Task<DeleteRoomViewModel> GetRoomDeleteById(Guid id)
        {
            var room = await this.roomRepository
                .GetAllAttached()
                .Where(r => r.Id == id)
                .Select(r => new DeleteRoomViewModel
                {
                    RoomName = r.RoomName
                })
                .FirstOrDefaultAsync();
            return room;
        }
        public async Task<bool> DeleteRoomAsync(Guid id)
        {
            Room? room = await this.roomRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(r => r.Id.ToString() == id.ToString());

            if (room != null)
            {
                await this.roomRepository.DeleteAsync(room.Id);
            }
            
            return true;
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

        public async Task<EditRoomViewModel> GetRoomEditByIdAsync(Guid id)
        {
            var room = await this.roomRepository
                .GetAllAttached()
                .Where(r => r.Id == id)
                .Select(r => new EditRoomViewModel
                {
                    RoomName = r.RoomName
                })
                .FirstOrDefaultAsync();
            return room;
        }

        public async Task<bool> UpdateRoomAsync(EditRoomViewModel model)
        {
            Room? room = await this.roomRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(r => r.Id.ToString() == model.Id);

            if (room == null)
            {
                return false;
            }

            room.RoomName = model.RoomName;
            await this.roomRepository.UpdateAysnc(room);
            return true;
        }
    }
}
