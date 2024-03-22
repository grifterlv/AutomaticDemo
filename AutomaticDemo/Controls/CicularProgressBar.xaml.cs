using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CicularProgressBar.xaml
    /// </summary>
    public partial class CicularProgressBar : UserControl
    {
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(CicularProgressBar), new PropertyMetadata(0.0, new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            (d as CicularProgressBar).Refresh();
        }

        public CicularProgressBar()
        {
            InitializeComponent();
            this.SizeChanged += CicularProgressBar_SizeChanged;
        }

        private void CicularProgressBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Refresh();
        }

        private void Refresh()
        {
            this.LayoutRoot.Width = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            double radius = this.LayoutRoot.Width / 2;
            if (radius <= 0) return;

            double newX = 0.0, newY = 0.0;
            newX = radius + (radius - 3) * Math.Cos((this.Value % 100 * 3.6 - 90) * Math.PI/180);
            newY = radius + (radius - 3) * Math.Sin((this.Value % 100 * 3.6 - 90) * Math.PI/180);

            string pathDataStr = "M{0} 3A{3} {3} 0 {4} 1 {1} {2}";
            pathDataStr = string.Format(pathDataStr,
                radius + 0.01, // {0}
                newX,          // {1}
                newY,          // {2}
                radius - 3,    // {3}
                this.Value < 50? 0:1); // {4}
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            
            // convert the string to a Geometry object
            this.path.Data = (Geometry)converter.ConvertFrom(pathDataStr);
        }
    }
}
