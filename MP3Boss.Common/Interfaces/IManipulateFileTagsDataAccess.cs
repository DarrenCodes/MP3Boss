using MP3Boss.Models.DTOs;

namespace MP3Boss.Common.Interfaces
{
    public interface IManipulateFileTagsDataAccess
    {
        FileTagsDTO Read(string filePath);
        void Write(FileTagsDTO fileTags);
        void Write(FileTagsDTO fileTags, string filePath);
        void Clear();
    }
}
