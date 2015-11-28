namespace MP3Boss.Source.GUI.Backend
{
    public interface IFormManager
    {
        void FillFileList(string[] dropedFiles);
        void RefreshListView();
        void SaveToFile(bool applyToAll, bool autoNext);
        void SetFormAttributes(int index);
        void Reset();
        void ManageSuggestions();
        bool ManageAdditionsToDB();
        void SearchAndReplace(string find, string replace, bool applyToAll);
        bool CheckDBFileAndSave(bool resetPath);
    }
}
