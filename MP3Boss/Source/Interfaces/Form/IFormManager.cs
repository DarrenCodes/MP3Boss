using MP3Boss.Source.Common.Form.Containers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MP3Boss.Source.Interfaces.Form
{
    public interface IFormManager
    {
        void fillFileList(string[] dropedFiles, ListView listViewAudioFiles);
        void refreshListView(ListView listViewAudioFiles);
        void saveToFile(bool applyToAll, bool autoNext,
            int format,
            ListView listViewAudioFiles);
        void loadFileTags(int index);
        void manageSuggestions();
        void searchAndReplace(string find, string replace, bool applyToAll);

        List<string> AudioFilesList { get; set; }
        Dictionary<int, string> AudioFilesPathDictionary { get; set; }
        bool FirstDragAndDrop { get; set; }
    }
}
