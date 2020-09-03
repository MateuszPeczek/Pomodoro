using Pomodoro.Core.Enums;
using Pomodoro.Core.Helpers;
using Pomodoro.Core.Interfaces;
using Pomodoro.Helpers;
using System;
using System.Windows.Input;

namespace Pomodoro.ViewModels
{
    public class MainPageModel : Observable
    {
        private readonly IAppState _appState;
        private readonly IAppLogic _appLogic;

        public MainPageModel(IAppState appState, IAppLogic appLogic)
        {
            _appState = appState;
            _appLogic = appLogic;

            _appState.StatusChanged += HandleAppStateStatusChanged;
            _appState.TimeRemainingChanged += HandleAppStateTimerChanged;
        }

        public ICommand ActionButtonCommand => new RelayCommand(ProcessActionButtonClick(), null);

        public int FocusTime
        {
            get { return _appState.FocusTime; }
            set 
            {
                _appLogic.SetFocusTime(value);
                OnPropertyChanged();
            }
        }

        public int BreakTime
        {
            get { return _appState.BreakTime; }
            set 
            { 
                _appLogic.SetBreakTime(value);
                OnPropertyChanged();
            }
        }

        public string StatusDescription { get { return _appState.CurrentStatus.GetEnumDescription(); } }
        public string TimerStringValue { get { return _appState.TimeRemaining.ToString(@"mm\:ss"); } }

        public string ActionButtonDescription
        {
            get
            {
                switch (_appState.CurrentStatus) {
                    case Status.Waiting:
                        return Resources.Resources.Start;
                    case Status.Break:
                    case Status.Focus:
                        return Resources.Resources.Stop;
                    default:
                        throw new ArgumentException("Invalid status value");
                };
            }
        }

        public Action ProcessActionButtonClick()
        {
            switch (_appState.CurrentStatus)
            {
                case Status.Waiting:
                    return new Action(_appLogic.StartFocus);
                case Status.Focus:
                case Status.Break:
                    return new Action(_appLogic.ResetPomodoro);
                default:
                    throw new ArgumentException("Invalid status value");
            }
        }

        private void HandleAppStateStatusChanged(object sender, EventArgs args)
        {
            OnPropertyChanged("StatusDescription");
            OnPropertyChanged("ActionButtonDescription");
            OnPropertyChanged("TimerStringValue");
        }

        private void HandleAppStateTimerChanged(object sender, EventArgs args)
        {
            OnPropertyChanged("TimerStringValue");
            OnPropertyChanged("ActionButtonCommand");
        }
    }
}
