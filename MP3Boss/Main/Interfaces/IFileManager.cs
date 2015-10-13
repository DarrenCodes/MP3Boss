using System.Collections.Generic;
namespace MP3Boss
{
    public interface IFileManager
    {
        List<string> getAudioFiles(string[] dropedFiles);
        bool renameAudioFile(string originalFile, string newFileName);
    }
}
