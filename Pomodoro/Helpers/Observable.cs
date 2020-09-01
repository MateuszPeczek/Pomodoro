using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pomodoro.Helpers
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T storedType, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storedType, value))
                return;

            storedType = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
