namespace Pomodoro.Core.Interfaces
{
    public interface IAppLogic
    {
        void ResetPomodoro();
        void SetBreakTime(int value);
        void SetFocusTime(int value);
        void StartFocus();
    }
}
