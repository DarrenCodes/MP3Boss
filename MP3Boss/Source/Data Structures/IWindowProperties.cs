using MP3Boss.Source.Objects.Requirements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace MP3Boss.Source.DataStructures
{
    public interface IWindowProperties : INotifyPropertyChanged, IReadAndWriteable<ObservableCollection<string>>
    {
        BitmapImage TagArt { get; set; }
        ObservableCollection<string> ListViewAudioFilesList { get; set; }
        List<string> FullPathAudioFilesList { get; set; }
        string StatusLabel { get; set; }
        string AudioFilesCountLabel { get; set; }
        string FilePathLabel { get; set; }

        int CurrentIndex { get; set; }
        int Format { get; set; }

        #region Locked Status
        bool CheckBoxTitle { get; set; }
        bool CheckBoxArtist { get; set; }
        bool CheckBoxContributingArtists { get; set; }
        bool CheckBoxAlbum { get; set; }
        bool CheckBoxYear { get; set; }
        bool CheckBoxTrackNo { get; set; }
        bool CheckBoxGenre { get; set; }
        #endregion
    }
}
