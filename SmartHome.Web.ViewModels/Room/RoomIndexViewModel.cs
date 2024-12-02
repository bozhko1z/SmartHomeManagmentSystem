using SmartHome.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static SmartHome.Commons.ValidationConstants.Room;

namespace SmartHome.Web.ViewModels.Room
{
    using Data.Models;
    public class RoomIndexViewModel : IMapFrom<Room>
    {
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(RoomMaxName)]
        [MinLength(RoomMinName)]
        public string RoomName { get; set; } = null!;
    }
}
