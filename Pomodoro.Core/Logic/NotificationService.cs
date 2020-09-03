using Pomodoro.Core.Interfaces;
using Windows.UI.Notifications;

namespace Pomodoro.Core.Logic
{
    public class NotificationService : INotificationService
    {
        private readonly IAppState _appState;
        private readonly IXMLService _xmlService;
        private readonly ToastNotifier _notifier;

        public NotificationService(IAppState appState, 
                                   IXMLService xmlService,
                                   ToastNotifier notifier)
        {
            _appState = appState;
            _xmlService = xmlService;
            _notifier = notifier;
        }

        public void ShowFocusNotification()
        {
            var title = "Focus!";
            var content = $"Stay focused for { _appState.FocusTime} {(_appState.FocusTime > 1 ? "minutes" : "minute")} to achieve great things!";

            var notification = CreateToastNotification(title, content);
            _notifier.Show(notification);
        }

        public void ShowTakeABreakNotification()
        {
            var title = "Hey! Get a rest :)";
            var content = $"Give yourself a break for { _appState.BreakTime} {(_appState.BreakTime > 1 ? "minutes" : "minute")}!";

            var notification = CreateToastNotification(title, content);
            _notifier.Show(notification);
        }

        private ToastNotification CreateToastNotification(string title, string content)
        {
            var xml = _xmlService.CreateToastNotificationXMLDocument(title, content);
            var notification = new ToastNotification(xml);

            return notification;
        }
    }
}
