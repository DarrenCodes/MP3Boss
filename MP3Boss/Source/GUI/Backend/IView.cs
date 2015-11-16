using System.Windows.Forms;
using System.Collections.Generic;
using MP3Boss.Source.Datastructures;

namespace MP3Boss.Source.GUI.Backend
{
    public interface IView
    {
        IFormComboBoxContainer GetComboBoxesContent();
        void SetComboBoxesContent(IFormComboBoxContainer tBoxContent);
        void SetComboBoxesContent(List<IFormComboBoxContainer> tBoxContent);

        IFormCheckBoxContainer GetCheckBoxes();

        void ManageFormComponents(bool directoryIsSet);

        int CurrentIndex { get; set; }
        string StatusLabel { get; set; }
        string ItemsCountLabel { get; set; }
        string FilePathLabel { get; set; }
        PictureBox TagArt { get; }
    }
}
