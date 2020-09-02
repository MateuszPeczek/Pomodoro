using System.ComponentModel;

namespace Pomodoro.Core.Interfaces
{
    public interface IObservable
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}
