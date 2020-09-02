using Pomodoro.Core.Enums;
using System;
using System.Timers;

namespace Pomodoro.Core.Interfaces
{
    public interface IAppState
    {
        Status CurrentStatus { get; set; }
        int BreakTime { get; set; }
        int FocusTime { get; set; }
        TimeSpan TimeRemaining { get; set; }
        event EventHandler StatusChanged;
        event EventHandler TimeRemainingChanged;
    }
}
