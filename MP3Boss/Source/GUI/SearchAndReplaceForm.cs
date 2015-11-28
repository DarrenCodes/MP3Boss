using MP3Boss.Source.GUI.Backend;
using System;

namespace MP3Boss.Source.GUI
{
    public partial class SearchAndReplaceForm : System.Windows.Forms.Form
    {
        IFormManager manageForm;
        public SearchAndReplaceForm(IFormManager manageForm)
        {
            InitializeComponent();
            this.manageForm = manageForm;
        }
        
        private void btnChange_Click(object sender, EventArgs e)
        {
            manageForm.SearchAndReplace(this.tBoxFind.Text, this.tBoxReplace.Text, this.cBoxSearchAll.Checked);
            this.Close();
        }
    }
}
