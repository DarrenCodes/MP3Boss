using System.Windows.Forms;

namespace MP3Boss
{
    public interface IFormManager
    {
        void refreshForm(IMainForm iMainForm, bool applyToAll = false);
        void setFormAttributes(string path, IMainForm iMainForm);
        string formChecker(TagLib.File mp3TagContent, IMainForm iMainForm);
        void manageSuggestions(IMainForm iMainForm);
        
        string UserDecision
        {
            get;
            set;
        }
    }
}
