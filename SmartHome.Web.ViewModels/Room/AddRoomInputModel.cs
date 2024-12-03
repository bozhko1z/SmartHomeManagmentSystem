using SmartHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SmartHome.Commons.EntityValidationMessages.Room;
using static SmartHome.Commons.ValidationConstants.Room;

namespace SmartHome.Web.ViewModels.Room
{
    using Data.Models;
    public class AddRoomInputModel : IMapTo<Room>
    {
        [Required(ErrorMessage = RoomNameValidationMessage)]
        [MinLength(RoomMinName)]
        [MaxLength(RoomMaxName)]
        public string RoomName { get; set; } = null!;
    }
}
