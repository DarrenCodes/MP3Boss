using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using MP3Boss.Source.Interfaces.Form;
using MP3Boss.Source.Common.Form.Containers;
using MP3Boss.Source.Classes.Form;
using MP3Boss.Source.Classes.Validation;
using MP3Boss.Source.Forms;
using MP3Boss.Source.Interfaces.Validate;

namespace MP3Boss.Source.Form
{
    public partial class MainForm : System.Windows.Forms.Form, IGUI
    {
        IFormManager manageForm;

        public MainForm()
        {
            InitializeComponent();
            manageForm = new FormManager(this);
            this.manageFormComponents(false);
        }

        #region Get and set form components

        public FormContent.ComboBoxesContent getComboBoxesContent()
        {
            FormContent.ComboBoxesContent tBoxContent = new FormContent.ComboBoxesContent();
            tBoxContent.title = this.comboBoxTitle.Text;
            tBoxContent.artistName = this.comboBoxAlbumArtist.Text;
            tBoxContent.contributingArtists = this.comboBoxContArtists.Text.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();
            tBoxContent.albumName = this.comboBoxAlbum.Text;
            if (this.comboBoxYear.Text == "")
                tBoxContent.songYear = 0;
            else
                uint.TryParse(this.comboBoxYear.Text, out tBoxContent.songYear);
            if (this.comboBoxTrackNo.Text == "")
                tBoxContent.trackNo = 0;
            else
                uint.TryParse(this.comboBoxTrackNo.Text, out tBoxContent.trackNo);
            tBoxContent.songGenre = this.comboBoxGenre.Text.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();

            return tBoxContent;
        }

        public void setComboBoxesContent(FormContent.ComboBoxesContent comboBoxContent)
        {
            if (this.cBoxTitle.Checked != true)
                this.comboBoxTitle.Text = comboBoxContent.title;
            if (this.cBoxAlbumArtist.Checked != true)
                this.comboBoxAlbumArtist.Text = comboBoxContent.artistName;
            string tempContributingArtists = "";
            if (comboBoxContent.contributingArtists == null)
                comboBoxContent.contributingArtists = new List<string>();
            if (this.cBoxContArtists.Checked != true)
            {
                this.comboBoxContArtists.Text = "";
                foreach (string item in comboBoxContent.contributingArtists)
                {
                    if (item != tempContributingArtists)
                    {
                        this.comboBoxContArtists.Text += item + ";";
                        tempContributingArtists = item;
                    }
                }
            }
            if (this.cBoxAlbum.Checked != true)
                this.comboBoxAlbum.Text = comboBoxContent.albumName;
            if (this.cBoxYear.Checked != true)
                this.comboBoxYear.Text = comboBoxContent.songYear.ToString();
            if (this.cBoxTrackNo.Checked != true)
                this.comboBoxTrackNo.Text = comboBoxContent.trackNo.ToString();
            string tempGenre = "";
            if (comboBoxContent.songGenre == null)
                comboBoxContent.songGenre = new List<string>();
            if (this.cBoxGenres.Checked != true)
            {
                this.comboBoxGenre.Text = "";
                foreach (string item in comboBoxContent.songGenre)
                {
                    if (item != tempGenre)
                    {
                        this.comboBoxGenre.Text += item + ";";
                        tempGenre = item;
                    }
                }
            }
        }

        public void setComboBoxesContent(List<FormContent.ComboBoxesContent> tBoxContent)
        {
            this.setComboBoxesContent(tBoxContent[0]);

            bool listIsEligible = (tBoxContent != null && tBoxContent.Count >= 1);

            if (this.cBoxTitle.Checked != true && listIsEligible)
            {
                string temp = "";
                comboBoxTitle.Items.Clear();

                foreach (FormContent.ComboBoxesContent song in tBoxContent)
                {
                    if (song.title != temp)
                    {
                        temp = song.title;
                        this.comboBoxTitle.Items.Add(song.title);
                    }
                }
            }
            if (this.cBoxAlbumArtist.Checked != true && listIsEligible)
            {
                string temp = "";
                comboBoxAlbumArtist.Items.Clear();

                foreach (FormContent.ComboBoxesContent song in tBoxContent)
                {
                    if (song.artistName != temp)
                    {
                        temp = song.artistName;
                        this.comboBoxAlbumArtist.Items.Add(song.artistName);
                    }
                }
            }
            if (this.cBoxContArtists.Checked != true && listIsEligible)
            {
                string temp = "";
                comboBoxContArtists.Items.Clear();

                temp = "";
                foreach (FormContent.ComboBoxesContent song in tBoxContent)
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
            if (this.cBoxAlbum.Checked != true && listIsEligible)
            {
                string temp = "";
                comboBoxAlbum.Items.Clear();

                foreach (FormContent.ComboBoxesContent song in tBoxContent)
                {
                    if (song.albumName != temp)
                    {
                        temp = song.albumName;
                        this.comboBoxAlbum.Items.Add(song.albumName);
                    }
                }
            }
            if (this.cBoxYear.Checked != true && listIsEligible)
            {
                uint temp = 0;
                comboBoxYear.Items.Clear();

                foreach (FormContent.ComboBoxesContent song in tBoxContent)
                {
                    if (song.songYear != temp)
                    {
                        temp = song.songYear;
                        this.comboBoxYear.Items.Add(song.songYear);
                    }
                }
            }
            if (this.cBoxTrackNo.Checked != true && listIsEligible)
            {
                uint temp = 0;
                comboBoxTrackNo.Items.Clear();

                foreach (FormContent.ComboBoxesContent song in tBoxContent)
                {
                    if (song.trackNo != temp)
                    {
                        temp = song.trackNo;
                        this.comboBoxTrackNo.Items.Add(song.trackNo);
                    }
                }
            }
            if (this.cBoxGenres.Checked != true && listIsEligible)
            {
                string temp = "";
                comboBoxGenre.Items.Clear();

                temp = "";
                foreach (FormContent.ComboBoxesContent song in tBoxContent)
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
        }

        public FormContent.CheckBoxesContent getCheckBoxes()
        {
            FormContent.CheckBoxesContent checkboxes = new FormContent.CheckBoxesContent();
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
            this.cBoxTitle.Checked = checkAll;
            this.cBoxAlbumArtist.Checked = checkAll;
            this.cBoxContArtists.Checked = checkAll;
            this.cBoxAlbum.Checked = checkAll;
            this.cBoxYear.Checked = checkAll;
            this.cBoxTrackNo.Checked = checkAll;
            this.cBoxGenres.Checked = checkAll;
        }

        #endregion

        #region Event handlers
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
            manageForm.fillFileList(dropedFiles, listViewAudioFiles);
            this.ItemsCountLabel = listViewAudioFiles.Items.Count.ToString();
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

        private void listViewAudioFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                this.StatusLabel = "";
                this.clearFormAttributes();

                this.CurrentIndex = listViewAudioFiles.FocusedItem.Index;

                manageForm.loadFileTags(this.CurrentIndex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearFormAttributes();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                manageForm.loadFileTags(this.CurrentIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                manageForm.saveToFile(cBoxApplyToAll.Checked, cBoxAutoNext.Checked,
                    comboBoxFormat.SelectedIndex,
                    this.listViewAudioFiles);
            }
        }

        private void cBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            this.setCheckBoxes(this.cBoxSelectAll.Checked);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            manageForm.refreshListView(this.listViewAudioFiles);
            this.FilePathLabel = manageForm.AudioFilesList[this.CurrentIndex];
        }

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

        private void btnSearchReplace_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form searchForm = new SearchAndReplaceForm(manageForm);
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
            manageForm.manageSuggestions();
        }
        #endregion

        #region Other helper methods

        public void manageFormComponents(bool directoryIsSet)
        {
            this.cBoxTitle.Enabled = directoryIsSet;
            this.cBoxAlbumArtist.Enabled = directoryIsSet;
            this.cBoxContArtists.Enabled = directoryIsSet;
            this.cBoxAlbum.Enabled = directoryIsSet;
            this.cBoxYear.Enabled = directoryIsSet;
            this.cBoxTrackNo.Enabled = directoryIsSet;
            this.cBoxGenres.Enabled = directoryIsSet;
            this.cBoxSelectAll.Enabled = directoryIsSet;

            this.comboBoxTitle.Enabled = directoryIsSet;
            this.comboBoxAlbumArtist.Enabled = directoryIsSet;
            this.comboBoxContArtists.Enabled = directoryIsSet;
            this.comboBoxAlbum.Enabled = directoryIsSet;
            this.comboBoxYear.Enabled = directoryIsSet;
            this.comboBoxTrackNo.Enabled = directoryIsSet;
            this.comboBoxGenre.Enabled = directoryIsSet;

            this.btnReset.Enabled = directoryIsSet;
            this.btnClear.Enabled = directoryIsSet;
            this.btnRefresh.Enabled = directoryIsSet;
            this.btnSave.Enabled = directoryIsSet;

            this.btnSearchReplace.Enabled = directoryIsSet;
            this.btnCheckFormMsg.Enabled = directoryIsSet;

            this.comboBoxFormat.Enabled = directoryIsSet;

            this.cBoxApplyToAll.Enabled = directoryIsSet;
            this.cBoxAutoNext.Enabled = directoryIsSet;

            this.btnSuggest.Enabled = directoryIsSet;
        }
        public void resetForm()
        {
            this.btnClear.PerformClick();
            this.listViewAudioFiles.Items.Clear();
            this.FilePathLabel = "";
            this.StatusLabel = "";
            this.ItemsCountLabel = "";
            this.cBoxSelectAll.Checked = false;
            this.setCheckBoxes(this.cBoxSelectAll.Checked);
            this.cBoxApplyToAll.Checked = false;
            this.cBoxAutoNext.Checked = false;
            this.tagArtPictureBox.Image = null;
            manageForm.AudioFilesList = new List<string>();
            manageForm.AudioFilesPathDictionary = new Dictionary<int, string>();
            manageForm.FirstDragAndDrop = true;
        }
        public void clearFormAttributes()
        {
            if (this.cBoxTitle.Checked != true)
            {
                this.comboBoxTitle.Text = "";
                this.comboBoxTitle.Items.Clear();
            }
            if (this.cBoxAlbumArtist.Checked != true)
            {
                this.comboBoxAlbumArtist.Text = "";
                this.comboBoxAlbumArtist.Items.Clear();
            }
            if (this.cBoxContArtists.Checked != true)
            {
                this.comboBoxContArtists.Text = "";
                this.comboBoxContArtists.Items.Clear();
            }
            if (this.cBoxAlbum.Checked != true)
            {
                this.comboBoxAlbum.Text = "";
                this.comboBoxAlbum.Items.Clear();
            }
            if (this.cBoxYear.Checked != true)
            {
                this.comboBoxYear.Text = "";
                this.comboBoxYear.Items.Clear();
            }
            if (this.cBoxTrackNo.Checked != true)
            {
                this.comboBoxTrackNo.Text = "";
                this.comboBoxTrackNo.Items.Clear();
            }
            if (this.cBoxGenres.Checked != true)
            {
                this.comboBoxGenre.Text = "";
                this.comboBoxGenre.Items.Clear();
            }
        }

        #endregion

        #region Variables & Properties

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (this.listViewAudioFiles.FocusedItem != null && this.listViewAudioFiles.FocusedItem.Index > -1)
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

        public PictureBox TagArt
        {
            get { return this.tagArtPictureBox; }
        }

        #endregion

    }
}
