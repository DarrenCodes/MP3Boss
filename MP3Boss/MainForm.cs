using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MP3Boss
{
    public struct formComboBoxes
    {
        public string title;
        public string artistName;
        public List<string> contributingArtists;
        public string albumName;
        public string songYear;
        public string trackNo;
        public List<string> songGenre;
    }

    public struct formCheckBoxes
    {
        public bool Title;
        public bool Artist;
        public bool ContArtists;
        public bool Album;
        public bool Year;
        public bool TrackNo;
        public bool Genres;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.manageFormComponents(false);
        }

        //Clears all text from the Main Form textboxs that are unchecked
        public void clearFormAttributes()
        {
            formCheckBoxes cBoxesState = this.getCheckBoxes();

            if (cBoxesState.Title != true) //Title
            {
                this.comboBoxTitle.Text = "";
                this.comboBoxTitle.Items.Clear();
            }
            if (cBoxesState.Artist != true) //Album Artist
            {
                this.comboBoxAlbumArtist.Text = "";
                this.comboBoxAlbumArtist.Items.Clear();
            }
            if (cBoxesState.ContArtists != true) //Contributing Artitst(s)
            {
                this.comboBoxContArtists.Text = "";
                this.comboBoxContArtists.Items.Clear();
            }
            if (cBoxesState.Album != true) //Album name
            {
                this.comboBoxAlbum.Text = "";
                this.comboBoxAlbum.Items.Clear();
            }
            if (cBoxesState.Year != true) //Year
            {
                this.comboBoxYear.Text = "";
                this.comboBoxYear.Items.Clear();
            }
            if (cBoxesState.TrackNo != true) //Track number
            {
                this.comboBoxTrackNo.Text = "";
                this.comboBoxTrackNo.Items.Clear();
            }
            if (cBoxesState.Genres != true) //Genre(s)
            {
                this.comboBoxGenre.Text = "";
                this.comboBoxGenre.Items.Clear();
            }
        }

        #region Get and set form components
        public formComboBoxes getComboBoxesContent()
        {
            formComboBoxes tBoxContent = new formComboBoxes();
            tBoxContent.title = this.comboBoxTitle.Text;
            tBoxContent.artistName = this.comboBoxAlbumArtist.Text;
            tBoxContent.contributingArtists = this.comboBoxContArtists.Text.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();
            tBoxContent.albumName = this.comboBoxAlbum.Text;
            tBoxContent.songYear = this.comboBoxYear.Text;
            tBoxContent.trackNo = this.comboBoxTrackNo.Text;
            tBoxContent.songGenre = this.comboBoxGenre.Text.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();

            return tBoxContent;
        }

        public void setComboBoxesContent(formComboBoxes comboBoxContent)
        {
            formCheckBoxes cBoxesState = getCheckBoxes();

            if (cBoxesState.Title != true && comboBoxContent.title != null) //Title
                this.comboBoxTitle.Text = comboBoxContent.title;
            if (cBoxesState.Artist != true && comboBoxContent.artistName != null) //Album Artist
                this.comboBoxAlbumArtist.Text = comboBoxContent.artistName;
            if (cBoxesState.ContArtists != true && comboBoxContent.contributingArtists != null) //Contributing Artitst(s)
            {
                foreach (string item in comboBoxContent.contributingArtists)
                {
                    this.comboBoxContArtists.Text += item + ";";
                }
            }
            if (cBoxesState.Album != true && comboBoxContent.albumName != null) //Album name
                this.comboBoxAlbum.Text = comboBoxContent.albumName;
            if (cBoxesState.Year != true && comboBoxContent.songYear != null) //Year
                this.comboBoxYear.Text = comboBoxContent.songYear;
            if (cBoxesState.TrackNo != true && comboBoxContent.trackNo != null) //Track number
                this.comboBoxTrackNo.Text = comboBoxContent.trackNo;
            if (cBoxesState.Genres != true && comboBoxContent.songGenre != null) //Genre(s)
            {
                foreach (string item in comboBoxContent.songGenre)
                {
                    this.comboBoxGenre.Text += item + ";";
                }
            }

            this.FormAttributesAreSet = true;
        }

        public void setComboBoxesContent(List<formComboBoxes> tBoxContent)
        {
            formCheckBoxes cBoxesState = getCheckBoxes();

            if (cBoxesState.Title != true && tBoxContent != null && tBoxContent.Count != 0) //Title
            {
                string temp = "";
                comboBoxTitle.Items.Clear();
                this.comboBoxTitle.Text = tBoxContent[0].title;
                foreach (formComboBoxes song in tBoxContent)
                {
                    if (song.title != temp)
                    {
                        temp = song.title;
                        this.comboBoxTitle.Items.Add(song.title);
                    }
                }
            }
            if (cBoxesState.Artist != true && tBoxContent != null && tBoxContent.Count != 0) //Album Artist
            {
                string temp = "";
                comboBoxAlbumArtist.Items.Clear();
                this.comboBoxAlbumArtist.Text = tBoxContent[0].artistName;
                foreach (formComboBoxes song in tBoxContent)
                {
                    if (song.artistName != temp)
                    {
                        temp = song.artistName;
                        this.comboBoxAlbumArtist.Items.Add(song.artistName);
                    }
                }
            }
            if (cBoxesState.ContArtists != true && tBoxContent != null && tBoxContent.Count != 0) //Contributing Artitst(s)
            {
                string temp = "";
                comboBoxContArtists.Items.Clear();
                foreach (string item in tBoxContent[0].contributingArtists)
                {
                    if (item != temp)
                    {
                        temp = item;
                        if (this.comboBoxContArtists.Text != item)
                            this.comboBoxContArtists.Text += item + ";";
                    }
                }
                temp = "";
                foreach (formComboBoxes song in tBoxContent)
                {
                    foreach (string item in song.contributingArtists)
                    {
                        if (item != temp)
                        {
                            temp = item;
                            this.comboBoxContArtists.Items.Add(item);
                        }
                    }
                }
            }
            if (cBoxesState.Album != true && tBoxContent != null && tBoxContent.Count != 0) //Album name
            {
                string temp = "";
                comboBoxAlbum.Items.Clear();
                this.comboBoxAlbum.Text = tBoxContent[0].albumName;
                foreach (formComboBoxes song in tBoxContent)
                {
                    if (song.albumName != temp)
                    {
                        temp = song.albumName;
                        this.comboBoxAlbum.Items.Add(song.albumName);
                    }
                }
            }
            if (cBoxesState.Year != true && tBoxContent != null && tBoxContent.Count != 0) //Year
            {
                string temp = "";
                comboBoxYear.Items.Clear();
                this.comboBoxYear.Text = tBoxContent[0].songYear;
                foreach (formComboBoxes song in tBoxContent)
                {
                    if (song.songYear != temp)
                    {
                        temp = song.songYear;
                        this.comboBoxYear.Items.Add(song.songYear);
                    }
                }
            }
            if (cBoxesState.TrackNo != true && tBoxContent != null && tBoxContent.Count != 0) //Track number
            {
                string temp = "";
                comboBoxTrackNo.Items.Clear();
                this.comboBoxTrackNo.Text = tBoxContent[0].trackNo;
                foreach (formComboBoxes song in tBoxContent)
                {
                    if (song.trackNo != temp)
                    {
                        temp = song.trackNo;
                        this.comboBoxTrackNo.Items.Add(song.trackNo);
                    }
                }
            }
            if (cBoxesState.Genres != true && tBoxContent != null && tBoxContent.Count != 0) //Genre(s)
            {
                string temp = "";
                comboBoxGenre.Items.Clear();
                foreach (string item in tBoxContent[0].songGenre)
                {
                    if (item != temp)
                    {
                        temp = item;
                        if (this.comboBoxGenre.Text != item)
                            this.comboBoxGenre.Text += item + ";";
                    }
                }
                temp = "";
                foreach (formComboBoxes song in tBoxContent)
                {
                    foreach (string item in song.songGenre)
                    {
                        if (item != temp)
                        {
                            temp = item;
                            this.comboBoxGenre.Items.Add(item);
                        }
                    }
                }
            }

            this.FormAttributesAreSet = true;
        }

        public formCheckBoxes getCheckBoxes()
        {
            formCheckBoxes checkboxes = new formCheckBoxes();
            checkboxes.Title = this.cBoxTitle.Checked;
            checkboxes.Artist = this.cBoxAlbumArtist.Checked;
            checkboxes.ContArtists = this.cBoxContArtists.Checked;
            checkboxes.Album = this.cBoxAlbum.Checked;
            checkboxes.Year = this.cBoxYear.Checked;
            checkboxes.TrackNo = this.cBoxTrackNo.Checked;
            checkboxes.Genres = this.cBoxGenres.Checked;

            return checkboxes;
        }

        private void setCheckBoxes(bool checkAll)
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
        }
        #endregion

        #region Event handlers
        //Drage & Drop in ListView
        private void listViewAudioFiles_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listViewAudioFiles_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] dropedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            IFileManager manageFiles = new FileManager();
            this.AudioFiles = (AudioFiles.Concat(manageFiles.getAudioFiles(dropedFiles))).ToList();

            this.refresh();
        }

        private void resetAllMenuItem_Click(object sender, EventArgs e)
        {
            this.resetForm();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void howToMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Drag & drop files and/or folders onto the big white box (list view component) to get started." +
            "\n\n" +
            "Select the item you want to work on by clicking on the item in the list view component." +
            "\n" +
            "Set all tags to the same value by ticking the checkbox next to the corresponding textbox." +
            "\n" +
            "Click on the S button to open the Search & Replace window." +
            "\n" +
            "Click on the C button to change the preselected options in the Check Form Message window." +
            "\n\n" +
            "Enjoy!",
                "Welcome",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //Changes the index according to the item selected in the listview
        private void listViewAudioFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                IFormManager manageForm = new FormManager();
                if (listViewAudioFiles.FocusedItem.Index >= 0)
                    this.CurrentIndex = this.listViewAudioFiles.FocusedItem.Index;
                else
                    this.CurrentIndex = 0;

                this.StatusLabel = "";
                this.clearFormAttributes();
                manageForm.setFormAttributes(this.AudioFiles[this.CurrentIndex], this);
            }
        }

        //Clears the textboxes in the Main Window
        private void btnClear_Click(object sender, EventArgs e)
        {
            IFormManager manageForm = new FormManager();

            this.clearFormAttributes();
        }

        //Resets the textboxes according to currently selected item in the listview
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                IFormManager manageForm = new FormManager();
                manageForm.setFormAttributes(AudioFiles[this.CurrentIndex], this);
            }
        }

        //Saves changes to file made by user
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                IFileManager manageFiles = new FileManager();
                Save save = new Save();
                save.saveManager(cBoxApplyToAll.Checked, cBoxAutoNext.Checked, comboBoxFormat.SelectedIndex, this);
            }
        }

        //Changes all checkboxes next to textboxes
        private void cBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            this.setCheckBoxes(this.cBoxSelectAll.Checked);
        }

        //Refreshes the listview and also the textboxes accordingly
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.refresh();
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
            IFileManager manageFiles = new FileManager();
            Form searchForm = new SearchAndReplaceForm(this);
            searchForm.Show();
        }

        //Calls the check form message box to change the current settings of the message box
        //Usually called when "apply to all" was selected before and the user would like to change that
        private void btnCheckFormMsg_Click(object sender, EventArgs e)
        {
            IVerify verify = new Verify();
            verify.checkFormMessage(true);
        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            IFormManager manageForm = new FormManager();
            manageForm.manageSuggestions(this);
        }
        #endregion

        #region Other helper methods
        public void refresh(bool applyToAll = true)
        {
            IFormManager manageForm = new FormManager();
            manageForm.refreshForm(this, applyToAll);
        }
        public void manageFormComponents(bool directoryIsSet)
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

                this.comboBoxTitle.Enabled = true;
                this.comboBoxAlbumArtist.Enabled = true;
                this.comboBoxContArtists.Enabled = true;
                this.comboBoxAlbum.Enabled = true;
                this.comboBoxYear.Enabled = true;
                this.comboBoxTrackNo.Enabled = true;
                this.comboBoxGenre.Enabled = true;

                this.btnReset.Enabled = true;
                this.btnClear.Enabled = true;
                this.btnRefresh.Enabled = true;
                this.btnSave.Enabled = true;

                this.btnSearchReplace.Enabled = true;
                this.btnCheckFormMsg.Enabled = true;

                this.comboBoxFormat.Enabled = true;

                this.cBoxApplyToAll.Enabled = true;
                this.cBoxAutoNext.Enabled = true;

                this.ComponentsAreEnabled = true;
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

                this.comboBoxTitle.Enabled = false;
                this.comboBoxAlbumArtist.Enabled = false;
                this.comboBoxContArtists.Enabled = false;
                this.comboBoxAlbum.Enabled = false;
                this.comboBoxYear.Enabled = false;
                this.comboBoxTrackNo.Enabled = false;
                this.comboBoxGenre.Enabled = false;

                this.btnReset.Enabled = false;
                this.btnClear.Enabled = false;
                this.btnRefresh.Enabled = false;
                this.btnSave.Enabled = false;

                this.btnSearchReplace.Enabled = false;
                this.btnCheckFormMsg.Enabled = false;

                this.comboBoxFormat.Enabled = false;

                this.cBoxApplyToAll.Enabled = false;
                this.cBoxAutoNext.Enabled = false;

                this.ComponentsAreEnabled = false;
            }
        }
        public void resetForm()
        {
            this.btnClear.PerformClick();
            this.listViewAudioFiles.Items.Clear();
            this.AudioFiles = new List<string>();
            this.FilePathLabel = "";
            this.StatusLabel = "";
            this.ItemsCountLabel = "";
            this.cBoxSelectAll.Checked = false;
            this.setCheckBoxes(this.cBoxSelectAll.Checked);
            this.cBoxApplyToAll.Checked = false;
            this.cBoxAutoNext.Checked = false;
        }
        #endregion

        #region Variables & Properties
        static List<string> audioFiles = new List<string>();
        public List<string> AudioFiles
        {
            get { return audioFiles; }
            set { audioFiles = value; }
        }

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (audioFiles != null && AudioFiles.Count > value)
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
        public string ItemsCountLabel
        {
            get { return this.lblItemsCount.Text; }
            set { this.lblItemsCount.Text = "Count: " + value; }
        }
        public string FilePathLabel
        {
            get { return this.lblFileName.Text; }
            set { this.lblFileName.Text = "Current File: " + value; }
        }

        private bool componentsAreEnabled = false;
        public bool ComponentsAreEnabled
        {
            get { return this.componentsAreEnabled; }
            set { this.componentsAreEnabled = value; }
        }

        private bool formAttributesAreSet = false;
        public bool FormAttributesAreSet
        {
            get { return this.formAttributesAreSet; }
            set { this.formAttributesAreSet = value; }
        }

        public ListView ListViewAudioFiles
        {
            get { return listViewAudioFiles; }
            set { listViewAudioFiles = value; }
        }
        #endregion

    }
}
