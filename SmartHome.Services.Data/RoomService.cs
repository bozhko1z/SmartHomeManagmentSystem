using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using SmartHome.Data.Repository.Interfaces;
using SmartHome.Services.Data.Interfaces;
using SmartHome.Services.Mapping;
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
        private IRepository<Room, Guid> roomRepository;
        public RoomService(IRepository<Room, Guid> roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public Task AddRoomAsync(AddRoomInputModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomIndexViewModel>> GetAllRoomsAsync()
        {
            IEnumerable<RoomIndexViewModel> rooms = await this.roomRepository
               .GetAllAttached()
               .To<RoomIndexViewModel>()
               .ToArrayAsync();

            return rooms;
        }

        public Task<RoomDescriptionModel> GetRoomDetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
