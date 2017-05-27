using MP3Boss.Source.File;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace MP3Boss.Source.ViewModels
{
    class FileTagsViewModel : INotifyPropertyChanged
    {
        #region Members
        FileTagTools fileTagTools;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public string Title { get { return fileTagTools.Title; } set { fileTagTools.Title = value; OnPropertyChanged(); } }
        public string Artist { get { return fileTagTools.Artist; } set { fileTagTools.Artist = value; OnPropertyChanged(); } }
        public string ContributingArtists { get { return fileTagTools.ContributingArtists; } set { fileTagTools.ContributingArtists = value; OnPropertyChanged(); } }
        public string Album { get { return fileTagTools.Album; } set { fileTagTools.Album = value; OnPropertyChanged(); } }
        public string Year { get { return fileTagTools.Year; } set { fileTagTools.Year = value; OnPropertyChanged(); } }
        public string TrackNo { get { return fileTagTools.TrackNo; } set { fileTagTools.TrackNo = value; OnPropertyChanged(); } }
        public string Genre { get { return fileTagTools.Genre; } set { fileTagTools.Genre = value; OnPropertyChanged(); } }

        public BitmapImage TagArt { get { return fileTagTools.TagArt; } }
        #endregion

        #region Constructor Methods
        public FileTagsViewModel(string filePath)
        {
            fileTagTools = new FileTagTools(filePath);
        }
        #endregion

        #region Methods
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}
