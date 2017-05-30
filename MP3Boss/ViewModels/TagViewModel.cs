﻿using MP3Boss.Common.Interfaces;
using MP3Boss.Models.Models;
using System.Windows.Media.Imaging;

namespace MP3Boss.ViewModels
{
    public class TagViewModel : IAmFileTags
    {
        #region Members
        IManipulateFileTagsLogic _manipulateFileTagsBLL;

        bool _selectAll;
        #endregion

        #region Properties 
        #region Data

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
        public bool SelectAll { get { return _selectAll; } set { _selectAll = value; UpdateCheckBoxes(value); } }
        #endregion
        #endregion

        #region Constructors

        public TagViewModel(IManipulateFileTagsLogic manipulateFileTagsBLL)
        {
            Title = new TagPair<string>();
            Artist = new TagPair<string>();
            ContributingArtists = new TagPair<string>();
            Album = new TagPair<string>();
            Year = new TagPair<string>();
            TrackNo = new TagPair<string>();
            Genre = new TagPair<string>();
            TagArt = new TagPair<BitmapImage>();

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

        private void UpdateCheckBoxes(bool selectAll)
        {
            Title.Locked = selectAll;
            Artist.Locked = selectAll;
            ContributingArtists.Locked = selectAll;
            Album.Locked = selectAll;
            Year.Locked = selectAll;
            TrackNo.Locked = selectAll;
            Genre.Locked = selectAll;
            TagArt.Locked = selectAll;
        }

        public void Clear()
        {
            Title.Item = string.Empty;
            Artist.Item = string.Empty;
            ContributingArtists.Item = string.Empty;
            Album.Item = string.Empty;
            Year.Item = string.Empty;
            TrackNo.Item = string.Empty;
            Genre.Item = string.Empty;
            TagArt.Item = null;
        }
        #endregion
    }
}
