using MP3Boss.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3Boss.Common.Interfaces
{
    public interface IManipulateFileDirectoryLogic
    {
        List<FilePathPair> GetFiles(string[] droppedPaths, bool performDeepSearch, string fileTypeFilters = null);
        FilePathPair Rename(string filePath, IAmFileTags fileTags, int format);
    }
}
