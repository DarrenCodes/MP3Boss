using System.Windows.Forms;
using System.Collections.Generic;
using MP3Boss.Source.Common.Form.Containers;

namespace MP3Boss.Source.Interfaces.Form
{
    public interface IGUI
    {
        FormContent.ComboBoxesContent getComboBoxesContent();
        void setComboBoxesContent(FormContent.ComboBoxesContent tBoxContent);
        void setComboBoxesContent(List<FormContent.ComboBoxesContent> tBoxContent);
        FormContent.CheckBoxesContent getCheckBoxes();
        void manageFormComponents(bool directoryIsSet);

        int CurrentIndex { get; set; }
        string StatusLabel { get; set; }
        string ItemsCountLabel { get; set; }
        string FilePathLabel { get; set; }
        PictureBox TagArt { get;}
    }
}
