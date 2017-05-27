using MP3Boss.Models.DTOs;

namespace MP3Boss.Common.Interfaces
{
    public interface IManipulateFileTagsDAL
    {
        FileTagsDTO Read(string filePath);
        void Write(FileTagsDTO fileTags);
        void Write(FileTagsDTO fileTags, string filePath);
    }
}
