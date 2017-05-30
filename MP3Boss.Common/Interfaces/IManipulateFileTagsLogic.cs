namespace MP3Boss.Common.Interfaces
{
    public interface IManipulateFileTagsLogic
    {
        void Load(string filePath, IAmFileTags fileTags);
        void  Save(IAmFileTags fileTags);
    }
}
