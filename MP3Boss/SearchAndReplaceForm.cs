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
        string[] mp3Files = null;
        int currentIndex = 0;

        public SearchAndReplaceForm(string[] paths, int index)
        {
            mp3Files = paths;
            currentIndex = index;

            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Save saveChanges = new Save();
            saveChanges.searchAndReplace(this.tBoxFind.Text, this.tBoxReplace.Text, mp3Files, this.currentIndex, this.cBoxSearchAll.Checked);
            Close();
        }
    }
}
