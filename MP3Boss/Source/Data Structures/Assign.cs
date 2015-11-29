using MP3Boss.Source.Objects.Requirements;
using System;
using System.Collections.ObjectModel;

namespace MP3Boss.Source.DataStructures
{
    public abstract class Assign
    {
        public static void AssignTo(IReadAndWriteable<ObservableCollection<string>> Left, IReadAndWriteable<string> Right, IWindowProperties LockedStatus)
        {
            Action<ObservableCollection<string>, string, bool> AddTo = (LHS, RHS, IsLocked) =>
            {
                if (!IsLocked)
                    if (!LHS.Contains(RHS))
                        LHS.Add(RHS);
            };

            AddTo(Left.Title, Right.Title, LockedStatus.CheckBoxTitle);
            AddTo(Left.Artist, Right.Artist, LockedStatus.CheckBoxArtist);
            AddTo(Left.ContributingArtists, Right.ContributingArtists, LockedStatus.CheckBoxContributingArtists);
            AddTo(Left.Album, Right.Album, LockedStatus.CheckBoxAlbum);
            AddTo(Left.Year, Right.Year, LockedStatus.CheckBoxYear);
            AddTo(Left.TrackNo, Right.TrackNo, LockedStatus.CheckBoxTrackNo);
            AddTo(Left.Genre, Right.Genre, LockedStatus.CheckBoxGenre);
        }
        public static void AssignTo(IReadAndWriteable<string> Left, IReadAndWriteable<ObservableCollection<string>> Right)
        {
            Left.Title = Right.Title[0];
            Left.Artist = Right.Artist[0];
            Left.ContributingArtists = Right.ContributingArtists[0];
            Left.Album = Right.Album[0];
            Left.Year = Right.Year[0];
            Left.TrackNo = Right.TrackNo[0];
            Left.Genre = Right.Genre[0];
        }
    }
}
