using MP3Boss.Source.Common.Form.Containers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MP3Boss.Source.Interfaces.File
{
    public interface IAudioFile
    {
        bool getAudioFiles(string[] dropedFiles, ListView listViewAudioFiles, List<string> audioFilesList, Dictionary<int, string> audioFilesDictionary);
        FormContent.ComboBoxesContent read(string filePath);
        bool write(string filePath, FormContent.ComboBoxesContent tagUpdates);
        string rename(string filePath, FormContent.ComboBoxesContent tags, int format);
        void searchAndReplace(string filePath, string find, string replace);
        void searchAndReplace(List<string> audioFilesList, string find, string replace);
    }
}
