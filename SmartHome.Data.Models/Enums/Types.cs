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

        public Types(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static readonly Types Switch = new Types(1, "Electronics");
        public static readonly Types Light = new Types(2, "Light");
        public static readonly Types Thermostat = new Types(3, "Thermostat");

        public static List<Types> GetAll() => new List<Types> { Switch, Light, Thermostat };
    }
}

