using System;
using System.Windows.Forms;
using System.Windows.Input;
using TimeWatchSecondScreen.Commands;
using TimeWatchSecondScreen.Core;
using TimeWatchSecondScreen.ViewModels.Base;

namespace TimeWatchSecondScreen.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructors

        public MainWindowViewModel()
        {
            _core = new MainWindowCore();
        }

        #endregion // Constructors

        #region Fields

        private readonly MainWindowCore _core;
        private bool _canExecute = true;
        private ICommand _startCommand;

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
                _canExecute = false;
                _core.ShowWindowInSecondScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanExecuteStartCommand()
        {
            return _canExecute;
        }

        #endregion StartCommand
    }
}