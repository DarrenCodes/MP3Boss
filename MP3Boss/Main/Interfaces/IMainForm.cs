using System.Windows.Forms;
using System.Collections.Generic;

namespace MP3Boss
{
    public interface IMainForm
    {
        string[] getTextBoxesContent();
        void setTextBoxesContent(string[] tBoxContent);
        bool[] getCheckBoxes();
        void setCheckBoxes(bool checkAll, bool[] cBoxes = null);
        void manageFormComponents(bool directoryIsSet);
        void refresh(bool applyToAll = true);

        List<string> MP3Files
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
        ListView ListViewMP3s
        {
            get;
            set;
        }
    }
}
