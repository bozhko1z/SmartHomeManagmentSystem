using System.ComponentModel.DataAnnotations;
using static SmartHome.Commons.ValidationConstants.Room;

namespace SmartHome.Web.ViewModels.Room
{
    public class RoomCheckItemViewModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(RoomMaxName)]
        [MinLength(RoomMinName)]
        public string RoomName { get; set; } = null!;

        public bool IsSelected { get; set; }
    }
}
