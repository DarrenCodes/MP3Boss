using System.Windows.Media.Imaging;

namespace MP3Boss.Models.DTOs
{
    public class FileTagsDTO
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string ContributingArtists { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string TrackNo { get; set; }
        public string Genre { get; set; }
        public BitmapImage TagArt { get; set; }
    }
}
