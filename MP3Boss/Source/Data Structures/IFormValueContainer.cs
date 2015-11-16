namespace MP3Boss.Source.Datastructures
{
    public interface IFormComboBoxContainer
    {
        string Title { get; set; }
        string Artist { get; set; }
        Iterate ContributingArtists { get; set; }
        string Album { get; set; }
        uint Year { get; set; }
        uint TrackNo { get; set; }
        Iterate Genre { get; set; }
    }

    public interface IFormCheckBoxContainer
    {
        bool Title { get; set; }
        bool Artist { get; set; }
        bool ContributingArtists { get; set; }
        bool Album { get; set; }
        bool Year { get; set; }
        bool TrackNo { get; set; }
        bool Genre { get; set; }
    }
}
