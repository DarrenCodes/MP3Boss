using System.Windows.Forms;
using System.Collections.Generic;

namespace MP3Boss
{
    public interface IMainForm
    {
        formComboBoxes getComboBoxesContent();
        void setComboBoxesContent(formComboBoxes tBoxContent);
        void setComboBoxesContent(List<formComboBoxes> tBoxContent);
        formCheckBoxes getCheckBoxes();
        void manageFormComponents(bool directoryIsSet);
        void refresh(bool applyToAll = true);

        List<string> AudioFiles
        {
            get;
            set;
        }
        int CurrentIndex
        {
            get;
            set;
        }
        string StatusLabel
        {
            get;
            set;
        }
        string ItemsCountLabel
        {
            get;
            set;
        }
        string FilePathLabel
        {
            get;
            set;
        }
        bool ComponentsAreEnabled
        {
            get;
            set;
        }
        bool FormAttributesAreSet
        {
            get;
            set;
        }
        ListView ListViewAudioFiles
        {
            get;
            set;
        }
    }
}
