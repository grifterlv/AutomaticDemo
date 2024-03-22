using AutomaticDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomaticDemo.Controls
{
    /// <summary>
    /// Interaction logic for RaderChart.xaml
    /// </summary>
    public partial class RadarChart : UserControl
    {

        public ObservableCollection<RadarSeriesModel> ItemsSources
        {
            get { return (ObservableCollection<RadarSeriesModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSources",
                typeof(ObservableCollection<RadarSeriesModel>),
                typeof(RadarChart),
                new PropertyMetadata(null, new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue == null) return;
            (args.NewValue as ObservableCollection<RadarSeriesModel>).CollectionChanged += (se, ev) =>
            {
                (d as RadarChart).Refresh();
            };
        }

        private void Refresh()
        {
            if (ItemsSources.Count == 0) return;

            this.mainCanvas.Children.Clear();
            this.p1.Points.Clear();
            this.p2.Points.Clear();
            this.p3.Points.Clear();
            this.p4.Points.Clear();
            this.p5.Points.Clear();

            // Set up area
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            this.LayoutRoot.Width = size;
            this.LayoutRoot.Height = size;
            double raduis = size / 2;
            double step = 360.0 / ItemsSources.Count;

            for (int i = 0; i < ItemsSources.Count; i++)
            {
                p1.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180),
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180)
                    ));
                p2.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180) * 0.25,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180) * 0.25
                    ));
                p3.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180) * 0.5,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180) * 0.5
                    ));
                p4.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180) * 0.75,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180) * 0.75
                    ));
                p5.Points.Add(new Point(
                   raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180) * ItemsSources[i].Value / 100,
                   raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180) * ItemsSources[i].Value / 100
                   ));

                Line line = new Line();
                line.Stroke = new SolidColorBrush(Color.FromArgb(34, 255, 255, 255));
                line.StrokeThickness = 1;
                line.X1 = raduis;
                line.Y1 = raduis;
                line.X2 = raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180);
                line.Y2 = raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180);
                this.mainCanvas.Children.Add(line);

                TextBlock text = new TextBlock();
                text.Width = 60;
                text.FontSize = 10;
                text.TextAlignment = TextAlignment.Center;
                text.Text = ItemsSources[i].Header;
                text.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                text.SetValue(Canvas.LeftProperty, raduis + (raduis - 10) * Math.Cos((step * i - 90) * Math.PI / 180)-30);
                text.SetValue(Canvas.TopProperty, raduis + (raduis - 10) * Math.Sin((step * i - 90) * Math.PI / 180)-7);
                this.mainCanvas.Children.Add(text);
            }
        }

        public RadarChart()
        {
            InitializeComponent();
            this.SizeChanged += RadarChart_SizeChanged;
        }

        private void RadarChart_SizeChanged(object sender, SizeChangedEventArgs arg)
        {
            this.Refresh();
        }
    }
}
