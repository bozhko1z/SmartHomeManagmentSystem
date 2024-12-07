using System.ComponentModel.DataAnnotations;
using static SmartHome.Commons.ValidationConstants.Room;
using static SmartHome.Commons.EntityValidationMessages.Room;

namespace SmartHome.Web.ViewModels.Room
{
    public class EditRoomViewModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = RoomNameValidationMessage)]
        [MinLength(RoomMinName)]
        [MaxLength(RoomMaxName)]
        public string RoomName { get; set; } = null!;
    }
}
