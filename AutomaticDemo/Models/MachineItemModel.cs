using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticDemo.Models
{
    internal class MachineItemModel
    {
        public string Name { get; set; }
        public double ProgressValue { get; set; }
        public string Status { get; set; }
        public string ProgressText { get; set; }
        public int ProductionCount { get; set; }
        public int ProductionGoal { get; set; }
        public string OrderNum { get; set; }
    }
}
