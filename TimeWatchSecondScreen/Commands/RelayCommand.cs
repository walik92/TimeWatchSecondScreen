using System;
using System.Windows.Input;

namespace TimeWatchSecondScreen.Commands
{
    public class RelayCommand : ICommand
    {
        #region Constructors

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion // Constructors

        #region Fields

        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        #endregion // Fields

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }
}