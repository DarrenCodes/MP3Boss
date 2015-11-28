using MP3Boss.Source.Datastructures;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MP3Boss.Source.GUI.Backend
{
    public interface IFormManager
    {
        void FillFileList(string[] dropedFiles, ListView listViewAudioFiles);
        void RefreshListView(ListView listViewAudioFiles);
        void SaveToFile(bool applyToAll, bool autoNext,
            int format,
            ListView listViewAudioFiles);
        void LoadFileTags(int index);
        void ManageSuggestions();
        bool ManageAdditionsToDB();
        bool CheckDBFileAndSave(bool resetPath);
        void SearchAndReplace(string find, string replace, bool applyToAll);

        List<string> AudioFilesList { get; set; }
        Iterate AudioFilesPathDictionary { get; set; }
        bool FirstDragAndDrop { get; set; }
    }
}
