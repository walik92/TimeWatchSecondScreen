using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using TimeWatchSecondScreen.Commands;
using TimeWatchSecondScreen.Views;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TimeWatchSecondScreen.ViewModels
{
    public class MainWindowViewModel
    {
        #region methods

        /// <summary>
        ///     Show WatchWindow if second screen is available
        /// </summary>
        private void ShowWindowInSecondScreen()
        {
            if (_watchWindow != null)
                throw new Exception("Watch window is open");

            _watchWindow = new WatchWindow();
            _watchWindow.Left = GetLeftEdgeSecondaryScreen();
            _watchWindow.Closed += CloseWatchWindow;
            _watchWindow.Show();
            _watchWindow.WindowState = WindowState.Maximized;
        }

        /// <summary>
        ///     Get left edge secondary screen
        /// </summary>
        /// <returns></returns>
        private int GetLeftEdgeSecondaryScreen()
        {
            var secondaryScreen = Screen.AllScreens.SingleOrDefault(q => q.Primary == false);
            if (secondaryScreen == null)
                throw new Exception("Sorry, Second screen is not available");
            return secondaryScreen.WorkingArea.Left;
        }

        #endregion //methods

        #region Events

        /// <summary>
        ///     Event closing MainWindow and WatchWindows (if is open)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (_watchWindow != null)
                _watchWindow.Close();
        }

        /// <summary>
        ///     Run after close watch window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWatchWindow(object sender, EventArgs e)
        {
            _watchWindow = null;
            _canExecuteStartButton = true;
        }

        #endregion //events

        #region Fields

        private bool _canExecuteStartButton = true;
        private ICommand _startCommand;
        private WatchWindow _watchWindow;
        private double _left;

        #endregion // Fields

        #region StartCommand

        public ICommand StartCommand
        {
            get
            {
                if (_startCommand == null)
                    _startCommand = new RelayCommand(param => ExecuteStartCommand(), param => CanExecuteStartCommand());
                return _startCommand;
            }
        }

        private void ExecuteStartCommand()
        {
            try
            {
                _canExecuteStartButton = false;
                ShowWindowInSecondScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _canExecuteStartButton = true;
            }
        }

        private bool CanExecuteStartCommand()
        {
            return _canExecuteStartButton;
        }

        #endregion // StartCommand
    }
}