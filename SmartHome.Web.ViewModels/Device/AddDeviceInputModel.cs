﻿using SmartHome.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartHome.Commons.ValidationConstants.Device;
using static SmartHome.Commons.EntityValidationMessages.Device;
using SmartHome.Services.Mapping;

namespace SmartHome.Web.ViewModels.Device
{
    using Data.Models;
    public class AddDeviceInputModel : IMapTo<Device>
    {
        [Required(ErrorMessage = DeviceNameValidationMessage)]
        [MaxLength(DeviceMaxName)]
        [MinLength(DeviceMinName)]
        public string DeviceName { get; set; } = null!;

        [Required(ErrorMessage = DeviceTypeValidationMessage)]
        public string DeviceType { get; set; }

        [Required(ErrorMessage = DeviceStatusValidationMessage)]
        [DefaultValue(DeviceDefaultStatus)]
        public bool Status { get; set; }
    }
}
