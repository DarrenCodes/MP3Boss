using MP3Boss.Source.Interfaces.Form;
using System;

namespace MP3Boss.Source.Forms
{
    public partial class SearchAndReplaceForm : System.Windows.Forms.Form
    {
        IFormManager manageForm;
        public SearchAndReplaceForm(IFormManager manager)
        {
            InitializeComponent();
            this.manageForm = manager;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            manageForm.searchAndReplace(this.tBoxFind.Text, this.tBoxReplace.Text, this.cBoxSearchAll.Checked);
            this.Close();
        }
    }
}
