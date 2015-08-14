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

        internal string[] files; //Stores all the MP3 files' paths

        internal bool fileScanIsDeep; //Used as a flag to indicate if a shallow or deep search was used for MP3 files
        internal bool formIsCompletedFlag = true;
        internal bool skipRestFlag = false;
        internal bool isInApplyToAll = false; //Used as flag to determine if the user is in an "Apply to All" process.

        internal int selectedIndex = 0, //Stores the index of the item selected in the listview
                     interruptedIndex = 0; //Stores the index of the listview item that prompts the user to make adjustments to tags
        internal int userFormat = 0; //Stores the comboBoxFormat selected item index

        //Method to get mp3 files to work on
        private void fileMenuOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = fBDialogLoadMP3s.ShowDialog(); //Used to store selected path

            if (result == DialogResult.OK)
            {
                fileScanIsDeep = false;
                obj.populateListView(this);
                if (listViewMP3s.Items.Count != 0)
                    obj.setFormAttributes(files[0], this);
            }
        }
        private void fileMenuOpenDeep_Click(object sender, EventArgs e)
        {
            DialogResult result = fBDialogLoadMP3s.ShowDialog(); //Used to store selected path

            if (result == DialogResult.OK)
            {
                fileScanIsDeep = true;
                obj.populateListView(this);
                if (listViewMP3s.Items.Count != 0)
                    obj.setFormAttributes(files[0], this);
            }
        }

        private void listViewMP3s_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listViewMP3s.FocusedItem.Index;
            obj.setFormAttributes(files[selectedIndex], this);
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
                    obj.setFormAttributes(files[selectedIndex], this);
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
                cBoxApplyToAll.Checked = false;
                formIsCompletedFlag = true;
                isInApplyToAll = true;

                for (interruptedIndex = 0; interruptedIndex < files.Length; interruptedIndex++)
                {
                    if (formIsCompletedFlag)
                    {
                        obj.setFormAttributes(files[interruptedIndex], this);
                        obj.formChecker(files[interruptedIndex], this);
                    }
                    else
                        break;
                }

                if (formIsCompletedFlag && listViewMP3s.Items.Count != 0)
                {
                    MessageBox.Show("Operation Completed!", "Happy days :)");
                    isInApplyToAll = false;
                    obj.populateListView(this);
                }
            }
            else if (listViewMP3s.Items.Count != 0)
            {
                try
                {
                    obj.formChecker(files[selectedIndex], this);
                    if (!isInApplyToAll && listViewMP3s.Items.Count != 0)
                    {
                        MessageBox.Show("Operation Completed!", "Happy days :)");
                    }
                    obj.populateListView(this);
                    if (isInApplyToAll)
                    {
                        cBoxApplyToAll.Checked = true;
                        comboBoxFormat.SelectedIndex = userFormat;
                        btnSave.PerformClick();
                    }
                }
                catch
                {
                    MessageBox.Show("No item selected.", "Warning!");
                }
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
            if (listViewMP3s.Items.Count != 0)
                obj.populateListView(this);
        }
    }
}

