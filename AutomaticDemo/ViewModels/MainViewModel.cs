using AutomaticDemo.Base;
using AutomaticDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticDemo.ViewModels
{
	class MainViewModel : NotifyBase
	{
		private object _pageContent;

		public object PageContent
		{
			get { return _pageContent; }
			set { SetProperty(ref _pageContent, value); }
		}

		private string _total;

		public string Total
		{
			get { return _total; }
			set { SetProperty(ref _total, value); }
		}

		private string _produtionCount;

		public string ProductionCount
		{
			get { return _produtionCount; }
			set {SetProperty(ref _produtionCount, value); }
		}

		private string _badProdcutionCount;

		public string BadProductionCount
		{
			get { return _badProdcutionCount; }
			set { SetProperty(ref _badProdcutionCount, value); }
		}

		public List<MonitorItemModel> EnvironmentalMonitors { get; set; }

		public MainViewModel()
		{
			Total = 197.ToString("0000");

			ProductionCount = 7147.ToString("00000");

			BadProductionCount = 17.ToString("000");

            #region initialize EnvironmentalMonitors
            EnvironmentalMonitors = new List<MonitorItemModel>();
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "光照(Lux)" });
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "噪音(db)" });
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "温度(°C)" });
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "湿度(%)" });
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "PM2.5(m³)" });
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "硫化氢(ppm)" });
			EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "氮气(ppm)" });
			#endregion

			EnvironmentalMonitors[0].MonitorValue = 123.98;
        }
    }

}
