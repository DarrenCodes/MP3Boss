using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MP3Boss.ViewModels
{
    class TagPairViewModel<T>
    {
        T _item;
        public T Item { get {return _item; } set {_item = value; OnPropertyChanged(); } }

        bool _lockedStatus;
        public bool LockedStatus { get { return _lockedStatus; } set { _lockedStatus = value; OnPropertyChanged(); } }

        event PropertyChangedEventHandler _propertyChanged;

        public TagPairViewModel(PropertyChangedEventHandler PropertyChanged)
        {
            _propertyChanged = PropertyChanged;
        }

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
