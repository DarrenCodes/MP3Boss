using System;
using System.IO;
using System.Windows.Forms;

namespace MP3Boss
{
    public partial class FormMP3Boss : Form
    {
        public FormMP3Boss()
        {
            InitializeComponent();
        }

        TagAndFormTools obj = new TagAndFormTools();

        internal string[] files;

        //Method to get mp3 files to work on
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fBDialogLoadMP3s.ShowDialog(); //Used to store selected path

            if (result == DialogResult.OK)
            {
                obj.populateListView(this);
                if (listViewMP3s.Items.Count != 0)
                    obj.setFormAttributes(files[0], this);
            }
        }

        private void listViewMP3s_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.setFormAttributes(files[listViewMP3s.FocusedItem.Index], this);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            obj.clearFormAttributes(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (listViewMP3s.Items.Count != 0)
            {
                try
                {
                    obj.setFormAttributes(files[listViewMP3s.FocusedItem.Index], this);
                }
                catch
                {
                    MessageBox.Show("No item selected.", "Warning!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cBoxApplyToAll.Checked == true)
            {
                int index = 0;
                foreach (var file in listViewMP3s.Items)
                {
                    obj.setFormAttributes(files[index], this);
                    obj.saveChangesToFile(files[index], this);
                    index++;
                }

                obj.populateListView(this);
            }
            else if (listViewMP3s.Items.Count != 0)
            {
                try
                {
                    obj.saveChangesToFile(files[listViewMP3s.FocusedItem.Index], this);
                    obj.populateListView(this);
                    obj.setFormAttributes(files[0], this);
                }
                catch
                {
                    MessageBox.Show("No item selected.", "Warning!");
                }

                obj.populateListView(this);
            }
        }

        private void cBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxSelectAll.Checked == true)
            {
                cBoxAlbumArtist.Checked = true;
                cBoxAlbum.Checked = true;
                cBoxContArtists.Checked = true;
                cBoxYear.Checked = true;
                cBoxTrackNo.Checked = true;
                cBoxGenre.Checked = true;
                cBoxTitle.Checked = true;
            }
            else
            {
                cBoxAlbumArtist.Checked = false;
                cBoxAlbum.Checked = false;
                cBoxContArtists.Checked = false;
                cBoxYear.Checked = false;
                cBoxTrackNo.Checked = false;
                cBoxGenre.Checked = false;
                cBoxTitle.Checked = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(listViewMP3s.Items.Count != 0)
                obj.populateListView(this);
        }
    }
}

