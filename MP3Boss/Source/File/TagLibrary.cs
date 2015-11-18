using MP3Boss.Source.Datastructures;
using MP3Boss.Source.Objects;

namespace MP3Boss.Source.File
{
    public class TagLibrary : ITagLibrary
    {
        TagLib.File audioFile;

        public TagLibrary(string file_path)
        {
            audioFile = TagLib.File.Create(file_path);
        }
        #region Properties
        public string Title
        {
            get { return audioFile.Tag.Title; }
            set { audioFile.Tag.Title = value; }
        }
        public string ArtistName
        {
            get { return audioFile.Tag.FirstAlbumArtist; }
            set { audioFile.Tag.AlbumArtists = new string[1] { value }; }
        }
        public Iterate ContributingArtistName
        {
            get
            {
                Iterate contributingArtists = ObjectFactory.GetIterator();
                foreach (string artist in audioFile.Tag.Performers)
                {
                    contributingArtists.Add(artist);
                }
                return contributingArtists;
            }
            set { audioFile.Tag.Performers = value.ToArray(); }
        }
        public string AlbumName
        {
            get { return audioFile.Tag.Album; }
            set { audioFile.Tag.Album = value; }
        }
        public uint SongYear
        {
            get { return audioFile.Tag.Year; }
            set { audioFile.Tag.Year = value; }
        }
        public uint TrackNo
        {
            get { return audioFile.Tag.Track; }
            set { audioFile.Tag.Track = value; }
        }
        public Iterate Genre
        {
            get
            {
                Iterate genres = ObjectFactory.GetIterator();
                foreach (string genre in audioFile.Tag.Genres)
                {
                    genres.Add(genre);
                }
                return genres;
            }
            set { audioFile.Tag.Genres = value.ToArray(); }
        }

        public void Save()
        {
            audioFile.Save();
        }
        #endregion
    }
}
