using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_monitor
{
    public class Kosc_ram{
        public string capacity { get; set; }
        public string manufacturer { get; set; }
        public string slot { get; set; }
        public string serial_number { get; set; }
        public string speed { get; set; }
        public string type { get; set; }

        public Kosc_ram(string capacity, string manufacturer, string slot, string serial_number, string speed, string type)
        {
            this.capacity = capacity;
            this.manufacturer = manufacturer;
            this.slot = slot;
            this.serial_number = serial_number;
            this.speed = speed;
            this.type = type;
        }
    }
}
