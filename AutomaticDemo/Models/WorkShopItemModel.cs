using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticDemo.Models
{
    class WorkShopItemModel
    {
        public string Name { get; set; }
        public int TotalMachineCount { get; set; }
        public int OperatingMachineCount { get; set; }
        public int WaitingMachineCount { get; set; }
        public int MalfunctionCount { get; set; }
        public int ShutdownCount { get; set; }
    }
}
