using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace MP3Boss
{
    public class FormManager : IFormManager
    {
        //Populates ListView with shortened strings from audioFiles string array (file names only)
        public void refreshForm(IMainForm iMainForm, bool applyToAll = false)
        {
            List<string> audioFiles = iMainForm.AudioFiles;
            if (audioFiles != null && audioFiles.Count != 0)
            {
                int currentIndex = iMainForm.CurrentIndex;
                ListView listViewAudioFiles = iMainForm.ListViewAudioFiles;

                if (applyToAll == true)
                {
                    listViewAudioFiles.Items.Clear();
                    //Adds list of files to List View element in GUI
                    foreach (string audioFile in audioFiles)
                    {
                        listViewAudioFiles.Items.Add(System.IO.Path.GetFileNameWithoutExtension(audioFile));
                    }
                }
                else if (applyToAll == false && (audioFiles != null && audioFiles.Count != 0))
                {
                    listViewAudioFiles.Items[currentIndex].Text = System.IO.Path.GetFileNameWithoutExtension(audioFiles[currentIndex]);
                }

                if (iMainForm.FormAttributesAreSet == false)
                    this.setFormAttributes(iMainForm.AudioFiles[currentIndex], iMainForm);

                if (iMainForm.ComponentsAreEnabled == false)
                    iMainForm.manageFormComponents(true);

                iMainForm.ItemsCountLabel = audioFiles.Count.ToString();
            }
        }

        //Public method used to set the form attributes according to the TagLib.FIle object passed
        public void setFormAttributes(string path, IMainForm iMainForm)
        {
            try
            {
                TagLib.File audioFileTagContent = null;
                formCheckBoxes cBoxState = new formCheckBoxes();
                formComboBoxes tBoxContent = new formComboBoxes();

                if (path != null && path.Length != 0)
                {
                    audioFileTagContent = TagLib.File.Create(path);
                    if (audioFileTagContent != null)
                    {
                        cBoxState = iMainForm.getCheckBoxes();

                        //Assigning tag properties to designated textboxes
                        if (cBoxState.Title != true)
                            tBoxContent.title = audioFileTagContent.Tag.Title;
                        if (cBoxState.Artist != true)
                            tBoxContent.artistName = audioFileTagContent.Tag.FirstAlbumArtist;
                        //Loop for finding & displaying all contributing artists from MP3 file (array)
                        if (cBoxState.ContArtists != true)
                        {
                            tBoxContent.contributingArtists = new List<string>();

                            foreach (string performers in audioFileTagContent.Tag.Performers)
                            {
                                tBoxContent.contributingArtists.Add(performers);
                            }
                        }
                        if (cBoxState.Album != true)
                            tBoxContent.albumName = audioFileTagContent.Tag.Album;
                        if (cBoxState.Year != true)
                            tBoxContent.songYear = audioFileTagContent.Tag.Year.ToString();
                        if (cBoxState.TrackNo != true)
                            tBoxContent.trackNo = audioFileTagContent.Tag.Track.ToString();
                        if (cBoxState.Genres != true)
                        {
                            tBoxContent.songGenre = new List<string>();

                            foreach (string genre in audioFileTagContent.Tag.Genres)
                            {
                                tBoxContent.songGenre.Add(genre);
                            }
                        }
                        iMainForm.setComboBoxesContent(tBoxContent);
                    }
                }
                else
                    MessageBox.Show("No path selected!", "Error!");
            }
            catch (TagLib.CorruptFileException)
            {
                MessageBox.Show("Error" +
                    "\nFile: " + path + " is either not a correct " + System.IO.Path.GetExtension(path) + " file, or it is corrupt.",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                iMainForm.FilePathLabel = path;
            }
        }

        //Checkes the form of the MainWindow for textboxes that contain null values
        public string formChecker(TagLib.File audioFileTagContent, IMainForm iMainForm)
        {
            IVerify iVerifyForm = new Verify();
            formComboBoxes tBoxContent = iMainForm.getComboBoxesContent();

            this.UserDecision = null;

            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.title, audioFileTagContent.Tag.Title);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.artistName, audioFileTagContent.Tag.AlbumArtists[0]);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.contributingArtists, audioFileTagContent.Tag.Performers);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.albumName, audioFileTagContent.Tag.Album);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.songYear, audioFileTagContent.Tag.Year.ToString());
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.trackNo, audioFileTagContent.Tag.Track.ToString());
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent.songGenre, audioFileTagContent.Tag.Genres);

            return this.UserDecision;
        }

        public void manageSuggestions(IMainForm iMainForm)
        {
            TagSuggest suggestions = new TagSuggest();
            formComboBoxes currentComboBoxContent = iMainForm.getComboBoxesContent();

            List<formComboBoxes> suggestionResults = suggestions.getSuggestions(currentComboBoxContent);

            if (suggestionResults.Count != 0)
                iMainForm.setComboBoxesContent(suggestionResults);
        }

        #region Variables and Properties
        static string userDecision = null;
        public string UserDecision
        {
            get { return userDecision; }
            set { userDecision = value; }
        }
        #endregion
    }
}
