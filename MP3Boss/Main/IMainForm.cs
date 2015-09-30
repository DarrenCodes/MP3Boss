using System.Windows.Forms;

namespace MP3Boss
{
    public interface IMainForm
    {
        string[] getTextBoxesContent();
        void setTextBoxesContent(string[] tBoxContent);
        bool[] getCheckBoxes();
        void setCheckBoxes(bool checkAll, bool[] cBoxes = null);
        void refreshForm();

        string[] MP3Files
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
        bool DirectoryIsSet
        {
            get;
            set;
        }
        bool SearchAndReplaceMode
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
