using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MP3Boss.Models.Models
{
    public class TagPair<T> : INotifyPropertyChanged
    {
        T _item;
        public T Item { get { return _item; } set { _item = value; OnPropertyChanged(); } }

        bool _locked;
        public bool Locked { get { return _locked; } set { _locked = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
