using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Commons
{
    public static class ValidationConstants
    {
        public static class Device
        {
            public const int DeviceMaxName = 20;
            public const int DeviceMinName = 5;

            public const bool DeviceDefaultStatus = false;
        }

        public static class Room
        {
            public const int RoomMaxName = 20;
            public const int RoomMinName = 4;
        }
    }
}
