using System.Windows.Forms;

namespace MP3Boss
{
    public interface IFormManager
    {
        void loadFilesOntoForm(IMainForm iMainForm, bool isDeepScan);
        void updateListView(IMainForm iMainForm, int index);
        void setFormAttributes(TagLib.File mp3TagContent, IMainForm iMainForm);
        void clearFormAttributes(IMainForm iMainForm);
        DialogResult formChecker(TagLib.File mp3TagContent, IMainForm iMainForm);
        
        DialogResult UserDecision
        {
            get;
            set;
        }
    }
}
