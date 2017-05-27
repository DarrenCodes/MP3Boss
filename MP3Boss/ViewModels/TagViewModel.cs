using MP3Boss.Common.Interfaces;
using MP3Boss.Models.Models;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace MP3Boss.ViewModels
{
    class TagViewModel : INotifyPropertyChanged, IAmFileTags
    {
        #region Properties 
        #region Data
        public event PropertyChangedEventHandler PropertyChanged;

        public TagPair<string> Title { get; }

        public TagPair<string> Artist { get; }

        public TagPair<string> ContributingArtists { get; }

        public TagPair<string> Album { get; }

        public TagPair<string> Year { get; }

        public TagPair<string> TrackNo { get; }

        public TagPair<string> Genre { get; }

        public TagPair<BitmapImage> TagArt { get; set; }
        #endregion

        #region General
        public bool DisableNotifyPropertyChangedEvent { get; set; }
        #endregion
        #endregion

        #region Members
        IManipulateFileTagsBLL _manipulateFileTagsBLL;
        #endregion

        #region Constructors

        public TagViewModel(IManipulateFileTagsBLL manipulateFileTagsBLL)
        {
            Title = new TagPair<string>(PropertyChanged);
            Artist = new TagPair<string>(PropertyChanged);
            ContributingArtists = new TagPair<string>(PropertyChanged);
            Album = new TagPair<string>(PropertyChanged);
            Year = new TagPair<string>(PropertyChanged);
            TrackNo = new TagPair<string>(PropertyChanged);
            Genre = new TagPair<string>(PropertyChanged);
            TagArt = new TagPair<BitmapImage>(PropertyChanged);

            _manipulateFileTagsBLL = manipulateFileTagsBLL;
        }

        #endregion

        #region Methods

        public void Save()
        {
            _manipulateFileTagsBLL.Save(this);
        }

        public void Load(string filePath)
        {
            _manipulateFileTagsBLL.Load(filePath, this);
        }
        #endregion
    }
}
