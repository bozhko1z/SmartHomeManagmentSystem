using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Models.Enums
{
    public class Types
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public static class AllTypes
        {
            public static readonly List<Types> All = new List<Types>
            {
                new Types { Id = 1, Name = "Light"},
                new Types { Id = 2, Name = "Switch"},
                new Types { Id = 3, Name = "Thermostat"}
            };
        }
    }
}
