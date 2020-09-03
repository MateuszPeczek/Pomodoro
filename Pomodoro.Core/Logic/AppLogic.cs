using Pomodoro.Core.Enums;
using Pomodoro.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pomodoro.Core.Logic
{
    public class AppLogic : IAppLogic
    {
        private const int _timerIntervalMilliseconds = 1000;

        private readonly IAppState _appState;
        private readonly INotificationService _notificationService;

        private CancellationTokenSource _source;

        public AppLogic(IAppState appState, INotificationService notificationService)
        {
            _appState = appState;
            _notificationService = notificationService;

            _source = new CancellationTokenSource();
        }

        public void SetFocusTime(int value) => _appState.FocusTime = value;
        public void SetBreakTime(int value) => _appState.BreakTime = value;

        public void ResetPomodoro()
        {
            _source.Cancel();
            _appState.CurrentStatus = Status.Waiting;
            _appState.TimeRemaining = new TimeSpan();
        }

        public async void StartFocus()
        {
            await StartCounting(_appState.FocusTime, Status.Focus);
        }

        private async void StartBreak()
        {
            await StartCounting(_appState.BreakTime, Status.Break);
        }

        private async Task StartCounting(int minutes, Status status)
        {
            _appState.CurrentStatus = status;
            _appState.TimeRemaining = TimeSpan.FromMinutes(minutes);

            try
            {
                while (_appState.CurrentStatus != Status.Waiting)
                {
                    await DelayedTimeSpanUpdate();
                    if (_appState.TimeRemaining.Minutes == 0 &&
                        _appState.TimeRemaining.Seconds == 0)
                    {
                        UpdateStatus();
                        break;
                    }
                }
            }
            catch (TaskCanceledException)
            {
                _source.Dispose();
                _source = new CancellationTokenSource();
            }
        }

        private async Task DelayedTimeSpanUpdate()
        {
            _appState.TimeRemaining = _appState.TimeRemaining.Subtract(TimeSpan.FromMilliseconds(_timerIntervalMilliseconds));
            await Task.Delay(_timerIntervalMilliseconds, _source.Token);
        }

        private void UpdateStatus()
        {
            switch (_appState.CurrentStatus)
            {
                case Status.Focus:
                    _notificationService.ShowTakeABreakNotification();
                    StartBreak();
                    break;
                case Status.Break:
                    _notificationService.ShowFocusNotification();
                    StartFocus();
                    break;
            }
        }
    }
}
