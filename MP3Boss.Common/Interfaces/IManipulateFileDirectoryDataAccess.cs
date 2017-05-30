namespace MP3Boss.Common.Interfaces
{
    public interface IManipulateFileDirectoryDataAccess
    {
        void RenameFile(string oldFileName, string newFileName);
        bool FileExists(string filePath);
        string GetFileName(string filePath);
        string[] GetFiles(string folderPath, bool performDeepSearch = false);
        bool DirectoryExists(string directoryPath);
        string GetDirectoryName(string directoryPath);
        string GetExtension(string path);
    }
}
