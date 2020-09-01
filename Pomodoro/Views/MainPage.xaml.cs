using Pomodoro.ViewModels;
using System.Windows;

namespace Pomodoro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
