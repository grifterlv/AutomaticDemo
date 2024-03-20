using AutomaticDemo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticDemo.Models
{
    class MonitorItemModel : NotifyBase
    {
        public string MonitorHeader { get; set; }
		
		private double _monitorValue;

		public double MonitorValue
		{
			get { return _monitorValue; }
			set { SetProperty(ref _monitorValue, value); }
		}

	}
}
