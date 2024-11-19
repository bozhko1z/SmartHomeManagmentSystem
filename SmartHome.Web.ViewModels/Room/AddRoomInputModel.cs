using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SmartHome.Commons.EntityValidationMessages.Room;
using static SmartHome.Commons.ValidationConstants.Room;

namespace SmartHome.Web.ViewModels.Room
{
    public class AddRoomInputModel
    {
        [Required(ErrorMessage = RoomNameValidationMessage)]
        [MinLength(RoomMinName)]
        [MaxLength(RoomMaxName)]
        public string RoomName { get; set; } = null!;
    }
}
