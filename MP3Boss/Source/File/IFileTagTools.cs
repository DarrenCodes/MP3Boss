using MP3Boss.Source.Objects.Requirements;

namespace MP3Boss.Source.File
{
    public interface IFileTagTools : IReadAndWriteable
    {
        void Save();
        System.Drawing.Image GetTagArt { get; }
    }
}
