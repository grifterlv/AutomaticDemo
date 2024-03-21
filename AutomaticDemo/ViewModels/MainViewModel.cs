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

		public ObservableCollection<RadarSeriesModel> RadarData {  get; set; }

		public List<PersonalItemModel> PersonalList { get; set; }

		public List<WorkShopItemModel> WorkShopList { get; set; }

		public MainViewModel()
        {
            Total = 197.ToString("0000");

            ProductionCount = 7147.ToString("00000");

            BadProductionCount = 17.ToString("000");

            #region initialize EnvironmentalMonitors
            EnvironmentalMonitors = new List<MonitorItemModel>();
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "Illumination (Lux)" });
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "Noise (db)" });
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "Temperature (°C)" });
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "Humidity (%)" });
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "PM2.5 (m³)" });
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "Hydrogen (ppm)" });
            EnvironmentalMonitors.Add(new MonitorItemModel { MonitorHeader = "Nitrogen (ppm)" });
            #endregion

            EnvironmentalMonitors[0].MonitorValue = 123.98;

			#region initialize AlarmsList
			AlarmsList = new List<AlarmItemModel>();
			AlarmsList.Add(new AlarmItemModel { Num = "01", Message= "Equipment temperature too high", Time="2024-03-09 20:12:09", Duration = 5});
			AlarmsList.Add(new AlarmItemModel { Num = "02", Message= "Workshop temperature too high", Time="2024-03-11 09:12:09", Duration = 5});
			AlarmsList.Add(new AlarmItemModel { Num = "03", Message= "Equipment speed too high", Time="2024-03-11 20:06:09", Duration = 5});
			#endregion

			#region initialize DeviceMonitors
			DeviceMonitors = new List<MonitorItemModel>();
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Electric (Kw.h)", MonitorValue= 512.12});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Voltage (V)", MonitorValue= 31.2});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Current (A)", MonitorValue= 258.6});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Pressure (kpa)", MonitorValue= 65.4});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Temperature (°C)", MonitorValue= 948.9});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Vibration (mm/s)", MonitorValue= 10.2});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Speed (r/min)", MonitorValue= 1000});
			DeviceMonitors.Add(new MonitorItemModel { MonitorHeader = "Air Pressure (kpa)", MonitorValue= 24});
			#endregion

			#region initialize Rader Data
			RadarData = new ObservableCollection<RadarSeriesModel>();
			Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
				RadarData.Add(new RadarSeriesModel { Header = "Tag" + i, Value = random.Next(20,100)});
            }
			#endregion

			#region initialize Personal Data
			PersonalList = new List<PersonalItemModel>();
			PersonalList.Add(new PersonalItemModel { Name = "Alex", Position = "Worker", WorkingHours = 288 });
			PersonalList.Add(new PersonalItemModel { Name = "Bob", Position = "Operator", WorkingHours = 258 });
			PersonalList.Add(new PersonalItemModel { Name = "Charles", Position = "Inspector", WorkingHours = 212 });
			PersonalList.Add(new PersonalItemModel { Name = "Deby", Position = "Supervisor", WorkingHours = 222 });
            #endregion

            #region initialize Workshop Data
            WorkShopList = new List<WorkShopItemModel>();
            WorkShopList.Add(new WorkShopItemModel { Name="SMT Workshop", TotalMachineCount=05, OperatingMachineCount=32, WaitingMachineCount=8, MalfunctionCount=2, ShutdownCount=1});
            WorkShopList.Add(new WorkShopItemModel { Name="Packaging Workshop", TotalMachineCount=45, OperatingMachineCount=32, WaitingMachineCount=8, MalfunctionCount=2, ShutdownCount=1});
            WorkShopList.Add(new WorkShopItemModel { Name= "Welding Workshop", TotalMachineCount=55, OperatingMachineCount=32, WaitingMachineCount=8, MalfunctionCount=2, ShutdownCount=1});
            WorkShopList.Add(new WorkShopItemModel { Name= "Assembly Workshop", TotalMachineCount=18, OperatingMachineCount=32, WaitingMachineCount=8, MalfunctionCount=2, ShutdownCount=1});
            WorkShopList.Add(new WorkShopItemModel { Name= "Painting Workshop", TotalMachineCount=99, OperatingMachineCount=32, WaitingMachineCount=8, MalfunctionCount=2, ShutdownCount=1});
            #endregion
        }
    }

}
