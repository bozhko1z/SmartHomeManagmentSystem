using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Commons
{
    public static class EntityValidationMessages
    {
        public static class Device
        {
            public const string DeviceNameValidationMessage = "Name is required!";
            public const string DeviceTypeValidationMessage = "Type is required!";
            public const string DeviceStatusValidationMessage = "Status is required!";
        }
    }
}
