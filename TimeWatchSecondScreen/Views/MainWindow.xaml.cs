using System.Linq;
using System.Windows;
using System.Windows.Forms;
using TimeWatchSecondScreen.ViewModels;

namespace TimeWatchSecondScreen.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            Closing += _viewModel.OnWindowClosing;
            DataContext = _viewModel;
            MoveToPrimaryScreen();
        }

        private void MoveToPrimaryScreen()
        {
            var primaryScreen = Screen.AllScreens.SingleOrDefault(q => q.Primary);
            if (primaryScreen != null)
            {
                var area = primaryScreen.WorkingArea;
                //center screen position
                Left = area.Width / 2 - Width / 2;
                Top = area.Height / 2 - Height / 2;
            }
        }
    }
}