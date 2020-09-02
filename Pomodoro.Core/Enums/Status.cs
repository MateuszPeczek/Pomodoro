using System.ComponentModel;

namespace Pomodoro.Core.Enums
{
    public enum Status
    {
        [Description(@"Waiting for start...")]
        Waiting,
        [Description(@"Take a break!")]
        Break,
        [Description(@"Focus!")]
        Focus
    }
}
