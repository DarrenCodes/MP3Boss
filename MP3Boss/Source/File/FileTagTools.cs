using System.IO;
using System.Windows.Media.Imaging;

namespace MP3Boss.Source.File
{
    public class FileTagTools : IFileTagTools, IFileTagImages
    {
        TagLib.File audioFile;

        public FileTagTools(string file_path)
        {
            if (System.IO.File.Exists(file_path))
                audioFile = TagLib.File.Create(file_path);
        }

        #region Properties
        public string Title
        {
            get { return audioFile.Tag.Title; }
            set { audioFile.Tag.Title = value; }
        }
        public string Artist
        {
            get { return audioFile.Tag.FirstAlbumArtist; }
            set { audioFile.Tag.AlbumArtists = new string[1] { value }; }
        }
        char[] filter = { ' ', ';' };
        public string ContributingArtists
        {
            get
            {
                string contributingArtists = "";
                foreach (string artist in audioFile.Tag.Performers)
                {
                    contributingArtists += artist + "; ";
                }
                return contributingArtists.TrimEnd(filter);
            }
            set { audioFile.Tag.Performers = value.Split(';'); }
        }
        public string Album
        {
            get { return audioFile.Tag.Album; }
            set { audioFile.Tag.Album = value; }
        }
        public string Year
        {
            get { return audioFile.Tag.Year.ToString(); }
            set { audioFile.Tag.Year = uint.Parse(value); }
        }
        public string TrackNo
        {
            get { return audioFile.Tag.Track.ToString(); }
            set { audioFile.Tag.Track = uint.Parse(value); }
        }
        public string Genre
        {
            get
            {
                string genres = "";
                foreach (string genre in audioFile.Tag.Genres)
                {
                    genres += genre + "; ";
                }
                return genres.TrimEnd(filter);
            }
            set { audioFile.Tag.Genres = value.Split(';'); }
        }

        public BitmapImage TagArt
        {
            get
            {
                if (!(audioFile.Tag.Pictures == null || audioFile.Tag.Pictures.Length == 0))
                {
                    BitmapImage image = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(audioFile.Tag.Pictures[0].Data.Data))
                    {
                        image.BeginInit();
                        image.StreamSource = ms;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                    }
                    return image;
                }
                else
                    return null;
            }
        }
        #endregion

        public void Save()
        {
            audioFile.Save();
        }
    }
}
