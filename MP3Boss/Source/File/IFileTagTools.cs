using MP3Boss.Source.Objects.Requirements;
using System.Windows.Media.Imaging;

namespace MP3Boss.Source.File
{
    public interface IFileTagImages
    {
        BitmapImage TagArt { get; }
    }
    public interface IFileTagTools: IReadAndWriteable<string>, IFileTagImages
    {
        void Save();
    }
}
