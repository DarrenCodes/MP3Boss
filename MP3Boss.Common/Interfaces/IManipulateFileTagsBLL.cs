﻿namespace MP3Boss.Common.Interfaces
{
    public interface IManipulateFileTagsBLL
    {
        void Load(string filePath, IAmFileTags fileTags);
        void  Save(IAmFileTags fileTags);
    }
}
