using System.Windows;
using TimeWatchSecondScreen.ViewModels;

namespace TimeWatchSecondScreen.Views
{
    /// <summary>
    ///     Interaction logic for WatchWindow.xaml
    /// </summary>
    public partial class WatchWindow : Window
    {
        private readonly WatchWindowViewModel _viewModel;

        public WatchWindow()
        {
            InitializeComponent();
            _viewModel = new WatchWindowViewModel();
            DataContext = _viewModel;
        }
    }
}