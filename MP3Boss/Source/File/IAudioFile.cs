using MP3Boss.Source.Datastructures;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MP3Boss.Source.File
{
    public interface IAudioFile
    {
        bool GetAudioFiles(string[] dropedFiles, ListView listViewAudioFiles, List<string> audioFilesList, Iterate audioFilesDictionary);
        IFormComboBoxContainer Read(string filePath);
        bool Write(string filePath, IFormComboBoxContainer tagUpdates);
        string Rename(string filePath, IFormComboBoxContainer tags, int format);
        void SearchAndReplace(string filePath, string find, string replace);
        void SearchAndReplace(List<string> audioFilesList, string find, string replace);
    }
}
