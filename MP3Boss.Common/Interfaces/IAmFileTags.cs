using MP3Boss.Models.Models;
using System.Windows.Media.Imaging;

namespace MP3Boss.Common.Interfaces
{
    public interface IAmFileTags
    {
        TagPair<string> Title { get; }
        TagPair<string> Artist { get; }
        TagPair<string> ContributingArtists { get; }
        TagPair<string> Album { get; }
        TagPair<string> Year { get; }
        TagPair<string> TrackNo { get; }
        TagPair<string> Genre { get; }
        TagPair<BitmapImage> TagArt { get; }
    }
}
