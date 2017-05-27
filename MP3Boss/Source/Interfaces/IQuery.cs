using MP3Boss.Source.Objects.Requirements;

namespace MP3Boss.Source.Database
{ 
    public interface IQuery : IReadAndWriteable<string>
    {
        bool ExecuteSQLQuery(string query);
        bool SQLNonQuery(string query);
        bool Read();
        bool IsNewSong { get; set; }
    }
}
