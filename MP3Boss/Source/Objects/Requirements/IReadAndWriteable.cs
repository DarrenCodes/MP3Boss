using MP3Boss.Source.Datastructures;

namespace MP3Boss.Source.Objects.Requirements
{
    public interface IReadAndWriteable
    {
        string Title { get; set; }
        string ArtistName { get; set; }
        Iterate ContributingArtistName { get; set; }
        string AlbumName { get; set; }
        uint SongYear { get; set; }
        uint TrackNo { get; set; }
        Iterate Genre { get; set; }
    }
}
