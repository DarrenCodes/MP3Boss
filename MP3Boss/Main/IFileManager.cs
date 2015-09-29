using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3Boss
{
    public interface IFileManager
    {
        string[] getMP3Files(bool directoryIsSet, bool isDeepScan);
        bool renameMP3File(string originalFile, string newFileName);
    }
}
