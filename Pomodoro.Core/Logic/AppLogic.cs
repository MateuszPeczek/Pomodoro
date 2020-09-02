using Pomodoro.Core.Enums;
using Pomodoro.Core.Interfaces;
using System;
using System.Timers;

namespace Pomodoro.Core.Logic
{
    public class AppLogic : IAppLogic
    {
        private const int _timerIntervalMilliseconds = 1000;

        private readonly IAppState _appState;

        private Timer _timer { get; set; } = new Timer(_timerIntervalMilliseconds);

        public AppLogic(IAppState appState)
        {
            _appState = appState;
            _timer.Elapsed += TimerElapsed;
        }

        public void SetFocusTime(int value) => _appState.FocusTime = value;
        public void SetBreakTime(int value) => _appState.BreakTime = value;

        public void ResetPomodoro()
        {
            _timer.Enabled = false;
            _appState.CurrentStatus = Status.Waiting;
            _appState.TimeRemaining = new TimeSpan();
        }

        public void StartFocus()
        {
            StartCounting(_appState.FocusTime, Status.Focus);
        }

        private void StartBreak()
        {
            StartCounting(_appState.BreakTime, Status.Break);
        }

        private void StartCounting(int minutes, Status status)
        {
            _appState.CurrentStatus = status;
            _appState.TimeRemaining = TimeSpan.FromMinutes(minutes);
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs args)
        {
            _appState.TimeRemaining = _appState.TimeRemaining.Subtract(TimeSpan.FromMilliseconds(_timerIntervalMilliseconds));
            if (_appState.TimeRemaining.Minutes == 0 &&
                _appState.TimeRemaining.Seconds == 0)
                    UpdateStatus();
        }

        private void UpdateStatus()
        {
            switch (_appState.CurrentStatus)
            {
                case Status.Focus:
                    StartBreak();
                    break;
                case Status.Break:
                    StartFocus();
                    break;
            }
        }
    }
}
