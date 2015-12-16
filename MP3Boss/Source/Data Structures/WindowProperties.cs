using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace MP3Boss.Source.DataStructures
{
    public class WindowProperties : IWindowProperties
    {
        public WindowProperties()
        {
            Title = new ObservableCollection<string>();
            Artist = new ObservableCollection<string>();
            ContributingArtists = new ObservableCollection<string>();
            Album = new ObservableCollection<string>();
            Year = new ObservableCollection<string>();
            TrackNo = new ObservableCollection<string>();
            Genre = new ObservableCollection<string>();

            ListViewAudioFilesList = new ObservableCollection<string>();
            FullPathAudioFilesList = new List<string>();
        }

        #region Tag Properties
        public ObservableCollection<string> Title { get; set; }
        public ObservableCollection<string> Artist { get; set; }
        public ObservableCollection<string> ContributingArtists { get; set; }
        public ObservableCollection<string> Album { get; set; }
        public ObservableCollection<string> Year { get; set; }
        public ObservableCollection<string> TrackNo { get; set; }
        public ObservableCollection<string> Genre { get; set; }

        private BitmapImage tagArt;
        public BitmapImage TagArt
        {
            get { return tagArt; }
            set { tagArt = value; OnPropertyChanged(); }
        }
        #endregion

        #region Window Elements Properties
        private string statusLabel = "Status: ";
        public string StatusLabel
        {
            get { return statusLabel; }
            set { statusLabel = "Status: " + value; OnPropertyChanged(); }
        }

        private string audioFilesCountLabel = "Count: ";
        public string AudioFilesCountLabel
        {
            get { return audioFilesCountLabel; }
            set { audioFilesCountLabel = "Count: " + value; OnPropertyChanged(); }
        }

        private string filePathLabel = "Current File: ";
        public string FilePathLabel
        {
            get { return filePathLabel; }
            set { filePathLabel = "Current File: " + value; OnPropertyChanged(); }
        }

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (value > 0)
                    currentIndex = value;
                else
                    currentIndex = 0;
            }
        }
        public int Format { get; set; }

        public ObservableCollection<string> ListViewAudioFilesList { get; set; }
        public List<string> FullPathAudioFilesList { get; set; }

        public bool CheckBoxTitle { get; set; }
        public bool CheckBoxArtist { get; set; }
        public bool CheckBoxContributingArtists { get; set; }
        public bool CheckBoxAlbum { get; set; }
        public bool CheckBoxYear { get; set; }
        public bool CheckBoxTrackNo { get; set; }
        public bool CheckBoxGenre { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
