using System.Collections.Generic;
namespace MP3Boss
{
    public interface IFileManager
    {
        List<string> getMP3Files(string[] dropedFiles);
        bool renameMP3File(string originalFile, string newFileName);
    }
}
