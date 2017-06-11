using System;
using System.Windows.Threading;
using TimeWatchSecondScreen.ViewModels.Base;

namespace TimeWatchSecondScreen.ViewModels
{
    public class WatchWindowViewModel : ViewModelBase
    {
        #region Constructor

        public WatchWindowViewModel()
        {
            DispatcherInit();
        }

        #endregion

        #region Properties

        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties

        #region Events

        private void Tick(object sender, EventArgs e)
        {
            Time = DateTime.Now;
        }

        #endregion //Events

        #region Methods

        /// <summary>
        ///     Init DispatcherTimer for refresh Time property
        /// </summary>
        private void DispatcherInit()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            _dispatcherTimer.Start();
        }

        #endregion //methods

        #region Fields

        private DispatcherTimer _dispatcherTimer;
        private DateTime _time;

        #endregion //fields
    }
}