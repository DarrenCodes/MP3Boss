using MP3Boss.Source.DataStructures;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MP3Boss.Source.File
{
    public interface IAudioFile
    {
        void GetAudioFiles(string[] dropedFiles, ObservableCollection<string> ListViewAudioFilesList, List<string> FullPathAudioFilesList);
        void Read(string filePath, IWindowProperties formPropertiesObject);
        bool Write(string filePath, IWindowProperties formPropertiesObject);
        string Rename(string filePath, IWindowProperties formPropertiesObject);
        void SearchAndReplace(string filePath, string find, string replace);
        void SearchAndReplace(List<string> audioFilesList, string find, string replace);
    }
}
