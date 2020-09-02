using Pomodoro.Core.Interfaces;

namespace Pomodoro.Core.Logic
{
    

    public class NotificationService : INotificationService
    {
        private readonly IAppState _appState;

        public NotificationService(IAppState appState)
        {
            _appState = appState;
        }

        public void ShowFocusNotification()
        {

        }

        public void ShowTakeABreakNotification()
        {

        }
    }
}
