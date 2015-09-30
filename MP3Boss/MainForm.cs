﻿using System;
using System.Windows.Forms;

namespace MP3Boss
{
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.manageFormComponents(false);
        }

        #region Get and set form components
        public string[] getTextBoxesContent()
        {
            string[] tBoxContent = new string[7];
            tBoxContent[0] = this.tBoxTitle.Text;
            tBoxContent[1] = this.tBoxAlbumArtist.Text;
            tBoxContent[2] = this.tBoxContArtists.Text;
            tBoxContent[3] = this.tBoxAlbum.Text;
            tBoxContent[4] = this.tBoxYear.Text;
            tBoxContent[5] = this.tBoxTrackNo.Text;
            tBoxContent[6] = this.tBoxGenre.Text;

            return tBoxContent;
        }

        public void setTextBoxesContent(string[] tBoxContent)
        {
            bool[] cBoxesState = getCheckBoxes();

            if (cBoxesState[0] != true) //Title
                this.tBoxTitle.Text = tBoxContent[0];
            if (cBoxesState[1] != true) //Album Artist
                this.tBoxAlbumArtist.Text = tBoxContent[1];
            if (cBoxesState[2] != true) //Contributing Artitst(s)
                this.tBoxContArtists.Text = tBoxContent[2];
            if (cBoxesState[3] != true) //Album name
                this.tBoxAlbum.Text = tBoxContent[3];
            if (cBoxesState[4] != true) //Year
                this.tBoxYear.Text = tBoxContent[4];
            if (cBoxesState[5] != true) //Track number
                this.tBoxTrackNo.Text = tBoxContent[5];
            if (cBoxesState[6] != true) //Genre(s)
                this.tBoxGenre.Text = tBoxContent[6];
        }

        public bool[] getCheckBoxes()
        {
            bool[] cBoxState = new bool[7];
            cBoxState[0] = this.cBoxTitle.Checked;
            cBoxState[1] = this.cBoxAlbumArtist.Checked;
            cBoxState[2] = this.cBoxContArtists.Checked;
            cBoxState[3] = this.cBoxAlbum.Checked;
            cBoxState[4] = this.cBoxYear.Checked;
            cBoxState[5] = this.cBoxTrackNo.Checked;
            cBoxState[6] = this.cBoxGenres.Checked;

            return cBoxState;
        }

        public void setCheckBoxes(bool checkAll, bool[] cBoxes = null)
        {
            if (checkAll == true)
            {
                this.cBoxTitle.Checked = true;
                this.cBoxAlbumArtist.Checked = true;
                this.cBoxContArtists.Checked = true;
                this.cBoxAlbum.Checked = true;
                this.cBoxYear.Checked = true;
                this.cBoxTrackNo.Checked = true;
                this.cBoxGenres.Checked = true;
            }
            else if (checkAll == false)
            {
                this.cBoxTitle.Checked = false;
                this.cBoxAlbumArtist.Checked = false;
                this.cBoxContArtists.Checked = false;
                this.cBoxAlbum.Checked = false;
                this.cBoxYear.Checked = false;
                this.cBoxTrackNo.Checked = false;
                this.cBoxGenres.Checked = false;
            }

            if (cBoxes != null)
            {
                this.cBoxTitle.Checked = cBoxes[0];
                this.cBoxAlbumArtist.Checked = cBoxes[1];
                this.cBoxContArtists.Checked = cBoxes[2];
                this.cBoxAlbum.Checked = cBoxes[3];
                this.cBoxYear.Checked = cBoxes[4];
                this.cBoxTrackNo.Checked = cBoxes[5];
                this.cBoxGenres.Checked = cBoxes[6];
            }
        }
        #endregion

        #region Event handlers
        //Calls a method which opens the folder browser dialog
        private void fileMenuOpen_Click(object sender, EventArgs e)
        {
            FormManager manageForm = new FormManager();

            this.directoryIsSet = false;
            this.isDeepScan = false;

            manageForm.loadFilesOntoForm(this, isDeepScan);

            if (MP3Files != null && MP3Files.Length != 0)
                this.manageFormComponents(true);
        }
        private void fileMenuOpenDeep_Click(object sender, EventArgs e)
        {
            FormManager manageForm = new FormManager();

            this.directoryIsSet = false;
            this.isDeepScan = true;

            manageForm.loadFilesOntoForm(this, isDeepScan);

            if (MP3Files != null && MP3Files.Length != 0)
                this.manageFormComponents(true);
        }

        //Changes the index according to the item selected in the listview
        private void listViewMP3s_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMP3s.Items.Count != 0)
            {
                FormManager manageForm = new FormManager();
                if (listViewMP3s.FocusedItem.Index >= 0)
                    this.CurrentIndex = listViewMP3s.FocusedItem.Index;
                else
                    this.CurrentIndex = 0;
                this.StatusLabel = "";
                TagLib.File mp3TagContent = TagLib.File.Create(MP3Files[this.CurrentIndex]);
                manageForm.setFormAttributes(mp3TagContent, this);
            }
        }

        //Clears the textboxes in the Main Window
        private void btnClear_Click(object sender, EventArgs e)
        {
            FormManager manageForm = new FormManager();

            manageForm.clearFormAttributes(this);
        }

        //Resets the textboxes according to currently selected item in the listview
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (listViewMP3s.Items.Count != 0)
            {
                FormManager manageForm = new FormManager();
                TagLib.File mp3TagContent = TagLib.File.Create(MP3Files[this.CurrentIndex]);
                manageForm.setFormAttributes(mp3TagContent, this);
            }
        }

        //Saves changes to file made by user
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewMP3s.Items.Count != 0)
            {
                FileManager manageFiles = new FileManager();
                Save save = new Save();
                string[] mp3Files = manageFiles.getMP3Files(directoryIsSet, isDeepScan);
                save.saveManager(cBoxApplyToAll.Checked, cBoxAutoNext.Checked, comboBoxFormat.SelectedIndex, this);
            }
        }

        //Changes all checkboxes next to textboxes
        private void cBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            this.setCheckBoxes(cBoxSelectAll.Checked);
        }

        //Refreshes the listview and also the textboxes accordingly
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        //Deselects the "auto next" checkbox if "apply to all" checkbox is set to "true"
        private void cBoxApplyToAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxApplyToAll.Checked)
            {
                cBoxAutoNext.Enabled = false;
                cBoxAutoNext.Checked = false;
            }
            else
                cBoxAutoNext.Enabled = true;
        }

        //Opens the Search & Replace window
        private void btnSearchReplace_Click(object sender, EventArgs e)
        {
            FileManager manageFiles = new FileManager();
            Form searchForm = new SearchAndReplaceForm(manageFiles.getMP3Files(directoryIsSet, isDeepScan), CurrentIndex);
            searchForm.Show();
        }
        #endregion

        public void refreshForm()
        {
            if (listViewMP3s.Items.Count != 0)
            {
                FormManager manageForm = new FormManager();
                manageForm.loadFilesOntoForm(this, isDeepScan);
            }
        }

        private void manageFormComponents(bool directoryIsSet)
        {
            if (directoryIsSet)
            {
                this.cBoxTitle.Enabled = true;
                this.cBoxAlbumArtist.Enabled = true;
                this.cBoxContArtists.Enabled = true;
                this.cBoxAlbum.Enabled = true;
                this.cBoxYear.Enabled = true;
                this.cBoxTrackNo.Enabled = true;
                this.cBoxGenres.Enabled = true;
                this.cBoxSelectAll.Enabled = true;

                this.tBoxTitle.Enabled = true;
                this.tBoxAlbumArtist.Enabled = true;
                this.tBoxContArtists.Enabled = true;
                this.tBoxAlbum.Enabled = true;
                this.tBoxYear.Enabled = true;
                this.tBoxTrackNo.Enabled = true;
                this.tBoxGenre.Enabled = true;

                this.btnReset.Enabled = true;
                this.btnClear.Enabled = true;
                this.btnRefresh.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnSearchReplace.Enabled = true;

                this.comboBoxFormat.Enabled = true;

                this.cBoxApplyToAll.Enabled = true;
                this.cBoxAutoNext.Enabled = true;

                this.listViewMP3s.Enabled = true;
            }
            else
            {
                this.cBoxTitle.Enabled = false;
                this.cBoxAlbumArtist.Enabled = false;
                this.cBoxContArtists.Enabled = false;
                this.cBoxAlbum.Enabled = false;
                this.cBoxYear.Enabled = false;
                this.cBoxTrackNo.Enabled = false;
                this.cBoxGenres.Enabled = false;
                this.cBoxSelectAll.Enabled = false;

                this.tBoxTitle.Enabled = false;
                this.tBoxAlbumArtist.Enabled = false;
                this.tBoxContArtists.Enabled = false;
                this.tBoxAlbum.Enabled = false;
                this.tBoxYear.Enabled = false;
                this.tBoxTrackNo.Enabled = false;
                this.tBoxGenre.Enabled = false;

                this.btnReset.Enabled = false;
                this.btnClear.Enabled = false;
                this.btnRefresh.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnSearchReplace.Enabled = false;

                this.comboBoxFormat.Enabled = false;

                this.cBoxApplyToAll.Enabled = false;
                this.cBoxAutoNext.Enabled = false;

                this.listViewMP3s.Enabled = false;
            }
        }

        #region Variables & Properties
        static string[] mp3Files = null;
        public string[] MP3Files
        {
            get { return mp3Files; }
            set { mp3Files = value; }
        }

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (mp3Files != null && mp3Files.Length > value)
                    currentIndex = value;
                else
                    currentIndex = 0;
            }
        }

        public string StatusLabel
        {
            get { return this.lblStatus.Text; }
            set { this.lblStatus.Text = "Status: " + value; }
        }

        private bool directoryIsSet = false;
        public bool DirectoryIsSet
        {
            get { return this.directoryIsSet; }
            set { this.directoryIsSet = value; }
        }

        private bool isDeepScan = false;

        private bool searchAndReplaceMode = false;
        public bool SearchAndReplaceMode
        {
            get { return this.searchAndReplaceMode; }
            set { this.searchAndReplaceMode = value; }
        }

        public ListView ListViewMP3s
        {
            get { return listViewMP3s; }
            set { listViewMP3s = value; }
        }
        #endregion
    }
}
