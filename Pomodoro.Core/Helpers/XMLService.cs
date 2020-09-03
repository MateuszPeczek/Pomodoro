using Pomodoro.Core.Interfaces;
using Windows.Data.Xml.Dom;

namespace Pomodoro.Core.Helpers
{
    public class XMLService : IXMLService
    {
        public XmlDocument CreateToastNotificationXMLDocument(string title, string content)
        {
            string toastXmlString =
                $@"<toast><visual>
                        <binding template='ToastGeneric'>
                        <text>{title}</text>
                        <text>{content}</text>
                        </binding>
                    </visual></toast>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(toastXmlString);

            return xmlDoc;
        }
    }
}
