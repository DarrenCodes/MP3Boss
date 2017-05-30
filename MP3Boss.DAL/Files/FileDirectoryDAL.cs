using MP3Boss.Common.Interfaces;
using System.IO;

namespace MP3Boss.DAL.Files
{
    public class FileDirectoryDAL : IManipulateFileDirectoryDAL
    {
        public void RenameFile(string currentFilePath, string newFileName)
        {
            File.Move(currentFilePath, newFileName);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public string[] GetFiles(string folderPath, bool performDeepSearch = false)
        {
            if (performDeepSearch)
                return Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            else
                return Directory.GetFiles(folderPath, "*.*");
        }

        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public string GetDirectoryName(string directoryPath)
        {
            return Path.GetDirectoryName(directoryPath);
        }

        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }
    }
}
