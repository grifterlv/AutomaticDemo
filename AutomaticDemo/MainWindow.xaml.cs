using AutomaticDemo.Base;
using AutomaticDemo.ViewModels;
using AutomaticDemo.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomaticDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public Command DetailsCommand { get; set; }

        public Command BackCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = mainViewModel;
            mainViewModel.PageContent = new MonitorView();
            
            DetailsCommand = new Command(ExecuteDetailsCommand);
            BackCommand = new Command(ExecuteBackCommand);

        }
        private void ExecuteDetailsCommand(object obj)
        {
            WorkShopView view = new WorkShopView();
            mainViewModel.PageContent = view;

            // position shift animation
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(
                new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0),
                new TimeSpan(0, 0, 0, 0, 400));

            // opacity animation
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, view);
            Storyboard.SetTarget(doubleAnimation, view);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);

            storyboard.Begin();
        }

        private void ExecuteBackCommand(object obj)
        {
            MonitorView monitorView = new MonitorView();
            mainViewModel.PageContent = monitorView;


            // opacity animation
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(doubleAnimation, monitorView);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(doubleAnimation);

            storyboard.Begin();
        }
    }
}