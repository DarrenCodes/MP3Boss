using System.Windows.Forms;

namespace MP3Boss
{
    public interface IFormManager
    {
        void refreshForm(IMainForm iMainForm, bool applyToAll = false);
        void setFormAttributes(string path, IMainForm iMainForm);
        void clearFormAttributes(IMainForm iMainForm);
        string formChecker(TagLib.File mp3TagContent, IMainForm iMainForm);
        
        string UserDecision
        {
            get;
            set;
        }
    }
}
