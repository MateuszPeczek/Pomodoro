using Windows.Data.Xml.Dom;

namespace Pomodoro.Core.Interfaces
{
    public interface IXMLService
    {
        XmlDocument CreateToastNotificationXMLDocument(string title, string content);
    }
}
