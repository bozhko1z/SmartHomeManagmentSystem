using SmartHome.Web.ViewModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.Data.Interfaces
{
    public interface IRoomService
    {
        Task AddRoomAsync(AddRoomInputModel model);

        Task<RoomDescriptionModel> GetRoomDetailsAsync(Guid id);

        Task<IEnumerable<RoomIndexViewModel>> GetAllRoomsAsync();
    }
}
