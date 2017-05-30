namespace MP3Boss.Source.Database
{
    public interface IQuery
    {
        bool ExecuteSQLQuery(string query);
        bool SQLNonQuery(string query);
        bool Read();
        bool IsNewSong { get; set; }
    }
}
