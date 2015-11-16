using MP3Boss.Source.Objects.Requirements;

namespace MP3Boss.Source.File
{
    public interface ITagLibrary : IReadAndWriteable
    {
        void Save();
    }
}
