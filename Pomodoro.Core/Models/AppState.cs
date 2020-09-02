using Pomodoro.Core.Enums;
using Pomodoro.Core.Interfaces;
using System;

namespace Pomodoro.Core.Models
{
    public class AppState : IAppState
    {
        public int FocusTime { get; set; } = 25;
        public int BreakTime { get; set; } = 5;

        private Status _status;
        public Status CurrentStatus
        {
            get { return _status; }
            set
            {
                _status = value;
                StatusChanged?.Invoke(this, null);
            }
        }

        private TimeSpan _timeRemaining;
        public TimeSpan TimeRemaining
        {
            get { return _timeRemaining; }
            set
            {
                _timeRemaining = value;
                TimeRemainingChanged?.Invoke(this, null);
            }
        }

        public event EventHandler StatusChanged;
        public event EventHandler TimeRemainingChanged;
    }
}
