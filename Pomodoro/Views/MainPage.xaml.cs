using MahApps.Metro.Controls;
using Pomodoro.ViewModels;

namespace Pomodoro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : MetroWindow
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
