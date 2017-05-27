namespace MP3Boss.Source.Objects.Requirements
{
    public interface IReadAndWriteable<T>
    {
        T Title { get; set; }
        T Artist { get; set; }
        T ContributingArtists { get; set; }
        T Album { get; set; }
        T Year { get; set; }
        T TrackNo { get; set; }
        T Genre { get; set; }
    }
}
