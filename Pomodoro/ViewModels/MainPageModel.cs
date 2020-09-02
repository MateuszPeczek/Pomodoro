using Pomodoro.Core.Enums;
using Pomodoro.Core.Helpers;
using Pomodoro.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Input;

namespace Pomodoro.ViewModels
{
    public class MainPageModel : Observable
    {
        private int _focusTime;
        public int FocusTime
        {
            get { return _focusTime; }
            set { Set(ref _focusTime, value); }
        }

        private int _breakTime;
        public int BreakTime
        {
            get { return _breakTime; }
            set { Set(ref _breakTime, value); }
        }

        private Status _currentStatus;
        public Status CurrentStatus
        {
            get { return _currentStatus; }
            set { Set(ref _currentStatus, value); }
        }

        public string StatusDescription { get { return _currentStatus.GetEnumDescription(); } }
    }
}
