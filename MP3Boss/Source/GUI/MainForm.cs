using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using MP3Boss.Source.GUI.Backend;
using MP3Boss.Source.Objects;
using MP3Boss.Source.Datastructures;
using MP3Boss.Source.Validation;

namespace MP3Boss.Source.GUI
{
    public partial class MainForm : System.Windows.Forms.Form, IView
    {
        IFormManager manageForm;

        public MainForm()
        {
            InitializeComponent();
            manageForm = ObjectFactory.GetFormManager(this);
            this.ManageFormComponents(false);
        }
        
        #region Get and set form components
        public IFormComboBoxContainer GetComboBoxesContent()
        {
            IFormComboBoxContainer tBoxContent = ObjectFactory.GetNewComboBoxContainer();
            tBoxContent.Title = this.comboBoxTitle.Text;
            tBoxContent.Artist = this.comboBoxAlbumArtist.Text;

            IEnumerable<string> ContributingArtists = this.comboBoxContArtists.Text.Split(';').Where(x => !string.IsNullOrEmpty(x));
            foreach (string artist in ContributingArtists)
            {
                tBoxContent.ContributingArtists.Add(artist);
            }

            tBoxContent.Album = this.comboBoxAlbum.Text;
            if (this.comboBoxYear.Text == "")
                tBoxContent.Year = 0;
            else
            {
                uint temp;
                uint.TryParse(this.comboBoxYear.Text, out temp);
                tBoxContent.Year = temp;
            }
            if (this.comboBoxTrackNo.Text == "")
                tBoxContent.TrackNo = 0;
            else
            {
                uint temp;
                uint.TryParse(this.comboBoxTrackNo.Text, out temp);
                tBoxContent.TrackNo = temp;
            }

            IEnumerable<string> Genre = this.comboBoxGenre.Text.Split(';').Where(x => !string.IsNullOrEmpty(x));
            foreach (string genre in Genre)
            {
                tBoxContent.Genre.Add(genre);
            }

            return tBoxContent;
        }

        public void SetComboBoxesContent(IFormComboBoxContainer comboBoxContent)
        {
            if (this.cBoxTitle.Checked != true)
                this.comboBoxTitle.Text = comboBoxContent.Title;
            if (this.cBoxAlbumArtist.Checked != true)
                this.comboBoxAlbumArtist.Text = comboBoxContent.Artist;

            if (this.cBoxContArtists.Checked != true)
            {
                this.comboBoxContArtists.Text = "";
                foreach (string artist in comboBoxContent.ContributingArtists)
                {
                    this.comboBoxContArtists.Text += artist + ";";
                }
            }
            if (this.cBoxAlbum.Checked != true)
                this.comboBoxAlbum.Text = comboBoxContent.Album;
            if (this.cBoxYear.Checked != true)
                this.comboBoxYear.Text = comboBoxContent.Year.ToString();
            if (this.cBoxTrackNo.Checked != true)
                this.comboBoxTrackNo.Text = comboBoxContent.TrackNo.ToString();

            if (this.cBoxGenres.Checked != true)
            {
                this.comboBoxGenre.Text = "";
                foreach (string genre in comboBoxContent.Genre)
                {
                    this.comboBoxGenre.Text += genre + ";";
                }
            }
        }

        public void SetComboBoxesContent(List<IFormComboBoxContainer> tBoxContent)
        {
            this.SetComboBoxesContent(tBoxContent[0]);

            bool listIsEligible = (tBoxContent != null && tBoxContent.Count >= 1);

            if (listIsEligible)
            {
                this.ClearComboBoxLists();

                foreach (IFormComboBoxContainer song in tBoxContent)
                {
                    if (this.cBoxTitle.Checked != true)
                    {
                        this.comboBoxTitle.Items.Add(song.Title);
                    }
                    if (this.cBoxAlbumArtist.Checked != true)
                    {
                        this.comboBoxAlbumArtist.Items.Add(song.Artist);
                    }
                    if (this.cBoxContArtists.Checked != true)
                    {
                        foreach (string artist in song.ContributingArtists)
                        {
                            this.comboBoxContArtists.Items.Add(artist);
                        }
                    }
                    if (this.cBoxAlbum.Checked != true)
                    {
                        this.comboBoxAlbum.Items.Add(song.Album);
                    }
                    if (this.cBoxYear.Checked != true)
                    {
                        this.comboBoxYear.Items.Add(song.Year);
                    }
                    if (this.cBoxTrackNo.Checked != true)
                    {
                        this.comboBoxTrackNo.Items.Add(song.TrackNo);
                    }
                    if (this.cBoxGenres.Checked != true)
                    {
                        foreach (string genre in song.Genre)
                        {
                            this.comboBoxGenre.Items.Add(genre);
                        }
                    }
                }
            }
        }

        public IFormCheckBoxContainer GetCheckBoxes()
        {
            IFormCheckBoxContainer checkboxes = ObjectFactory.GetNewCheckBoxContainer();
            checkboxes.Title = this.cBoxTitle.Checked;
            checkboxes.Artist = this.cBoxAlbumArtist.Checked;
            checkboxes.ContributingArtists = this.cBoxContArtists.Checked;
            checkboxes.Album = this.cBoxAlbum.Checked;
            checkboxes.Year = this.cBoxYear.Checked;
            checkboxes.TrackNo = this.cBoxTrackNo.Checked;
            checkboxes.Genre = this.cBoxGenres.Checked;

            return checkboxes;
        }

        private void SetCheckBoxes(bool checkAll)
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
        private void listViewAudioFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listViewAudioFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            manageForm.FillFileList(dropedFiles, listViewAudioFiles);
            this.ItemsCountLabel = listViewAudioFiles.Items.Count.ToString();
        }

        private void resetAllMenuItem_Click(object sender, EventArgs e)
        {
            this.ResetForm();
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
                this.ClearFormAttributes();

                this.CurrentIndex = listViewAudioFiles.FocusedItem.Index;

                manageForm.LoadFileTags(this.CurrentIndex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFormAttributes();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                manageForm.LoadFileTags(this.CurrentIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewAudioFiles.Items.Count != 0)
            {
                manageForm.SaveToFile(cBoxApplyToAll.Checked, cBoxAutoNext.Checked,
                    comboBoxFormat.SelectedIndex,
                    this.listViewAudioFiles);
            }
        }

        private void cBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            this.SetCheckBoxes(this.cBoxSelectAll.Checked);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            manageForm.RefreshListView(this.listViewAudioFiles);
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
            IVerify verify = ObjectFactory.GetVerifier();
            verify.checkFormMessage(true);
        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            manageForm.ManageSuggestions();
        }

        Stopwatch timeElapsed = new Stopwatch();
        private void btnSuggest_Hold(object sender, MouseEventArgs e)
        {
            timeElapsed.Reset();
            timeElapsed.Start();
        }

        private void BtnSuggest_Release(object sender, MouseEventArgs e)
        {
            timeElapsed.Stop();
            if (timeElapsed.ElapsedMilliseconds >= 1000)
            {
                manageForm.CheckDBFileAndSave(true);
            }
        }
        #endregion

        #region Other helper methods
        public void ManageFormComponents(bool directoryIsSet)
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
        public void ResetForm()
        {
            this.btnClear.PerformClick();
            this.listViewAudioFiles.Items.Clear();
            this.FilePathLabel = "";
            this.StatusLabel = "";
            this.ItemsCountLabel = "";
            this.cBoxSelectAll.Checked = false;
            this.SetCheckBoxes(this.cBoxSelectAll.Checked);
            this.cBoxApplyToAll.Checked = false;
            this.cBoxAutoNext.Checked = false;
            this.tagArtPictureBox.Image = null;
            manageForm.AudioFilesList = new List<string>();
            manageForm.AudioFilesPathDictionary = new Iterator();
            manageForm.FirstDragAndDrop = true;
        }
        public void ClearFormAttributes()
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

        void ClearComboBoxLists()
        {
            this.comboBoxTitle.Items.Clear();
            this.comboBoxAlbumArtist.Items.Clear();
            this.comboBoxContArtists.Items.Clear();
            this.comboBoxAlbum.Items.Clear();
            this.comboBoxYear.Items.Clear();
            this.comboBoxTrackNo.Items.Clear();
            this.comboBoxGenre.Items.Clear();
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
