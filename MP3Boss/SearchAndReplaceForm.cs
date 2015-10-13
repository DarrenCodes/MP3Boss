using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Boss
{
    public partial class SearchAndReplaceForm : Form
    {
        IMainForm iMainForm = null;

        public SearchAndReplaceForm(IMainForm mainFormObj)
        {
            iMainForm = mainFormObj;

            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ISave saveChanges = new Save();
            saveChanges.searchAndReplace(this.tBoxFind.Text, this.tBoxReplace.Text, iMainForm.AudioFiles, iMainForm.CurrentIndex, this.cBoxSearchAll.Checked);
            iMainForm.refresh();
            this.Close();
        }
    }
}
