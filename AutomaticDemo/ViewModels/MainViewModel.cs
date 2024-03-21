using AutomaticDemo.Base;
using AutomaticDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			set { SetProperty(ref _produtionCount, value); }
		}

		private string _badProdcutionCount;

		public string BadProductionCount
		{
			get { return _badProdcutionCount; }
			set { SetProperty(ref _badProdcutionCount, value); }
		}

		public List<MonitorItemModel> EnvironmentalMonitors { get; set; }

		public List<MonitorItemModel> DeviceMonitors { get; set; }

		public List<AlarmItemModel> AlarmsList { get; set; }

		public ObservableCollection<RadarSeriesModel> RadarData {  get; set;}

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

			#region initialize AlarmsList
			AlarmsList = new List<AlarmItemModel>();
			AlarmsList.Add(new AlarmItemModel { Num = "01", Message="设备温度过高", Time="2024-03-09 20:12:09", Duration = 5});
			AlarmsList.Add(new AlarmItemModel { Num = "02", Message="车间温度过高", Time="2024-03-11 09:12:09", Duration = 5});
			AlarmsList.Add(new AlarmItemModel { Num = "03", Message="设备转速过高", Time="2024-03-11 20:06:09", Duration = 5});
			#endregion

			#region initialize DeviceMonitors
			DeviceMonitors = new List<MonitorItemModel>();
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "电能(Kw.h)", MonitorValue= 512.12});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "电压(V)", MonitorValue= 31.2});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "电流(A)", MonitorValue= 258.6});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "压差(kpa)", MonitorValue= 65.4});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "温度(°C)", MonitorValue= 948.9});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "振动(mm/s)", MonitorValue= 10.2});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "转速(r/min)", MonitorValue= 1000});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "气压(kpa)", MonitorValue= 24});
			#endregion

			#region initialize Rader Data
			RadarData = new ObservableCollection<RadarSeriesModel>();
			Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
				RadarData.Add(new RadarSeriesModel { Header = "Tag" + i, Value = random.Next(20,100)});
            }
            #endregion
        }
    }

}
