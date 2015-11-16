using MP3Boss.Source.Objects;
using MP3Boss.Source.Objects.Requirements;

namespace MP3Boss.Source.Datastructures
{
    public class ComboBoxesContent : IFormComboBoxContainer
    {
        #region Properties
        public string Title { get; set; }
        public string Artist { get; set; }
        public Iterate ContributingArtists { get; set; }
        public string Album { get; set; }
        public uint Year { get; set; }
        public uint TrackNo { get; set; }
        public Iterate Genre { get; set; }
        #endregion

        public ComboBoxesContent()
        {
            Title = "";
            Artist = "";
            ContributingArtists = ObjectFactory.GetIterator();
            Album = "";
            Year = 0;
            TrackNo = 0;
            Genre = ObjectFactory.GetIterator();
        }
        public ComboBoxesContent(IFormComboBoxContainer obj)
        {
            Title = obj.Title;
            Artist = obj.Artist;
            ContributingArtists = obj.ContributingArtists;
            Album = obj.Album;
            Year = obj.Year;
            TrackNo = obj.TrackNo;
            Genre = obj.Genre;
        }
        public ComboBoxesContent(IReadAndWriteable obj)
        {
            Title = obj.Title;
            Artist = obj.ArtistName;
            ContributingArtists = obj.ContributingArtistName;
            Album = obj.AlbumName;
            Year = obj.SongYear;
            TrackNo = obj.TrackNo;
            Genre = obj.Genre;
        }
    }

    public class CheckBoxesContent : IFormCheckBoxContainer
    {
        #region Properties
        public bool Title { get; set; }
        public bool Artist { get; set; }
        public bool ContributingArtists { get; set; }
        public bool Album { get; set; }
        public bool Year { get; set; }
        public bool TrackNo { get; set; }
        public bool Genre { get; set; }
        #endregion
    }
}
