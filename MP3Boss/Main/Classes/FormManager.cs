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
                bool[] cBoxState = null;
                string[] tBoxContent = null;

                if (path != null && path.Length != 0)
                {
                    audioFileTagContent = TagLib.File.Create(path);
                    if (audioFileTagContent != null)
                    {
                        cBoxState = iMainForm.getCheckBoxes();
                        tBoxContent = new string[7];

                        //Assigning tag properties to designated textboxes
                        if (cBoxState[0] != true)
                            tBoxContent[0] = audioFileTagContent.Tag.Title;
                        if (cBoxState[1] != true)
                            tBoxContent[1] = audioFileTagContent.Tag.FirstAlbumArtist;
                        //Loop for finding & displaying all contributing artists from MP3 file (array)
                        if (cBoxState[2] != true)
                        {
                            foreach (string performers in audioFileTagContent.Tag.Performers)
                            {
                                tBoxContent[2] += performers + ";";
                            }
                        }
                        if (cBoxState[3] != true)
                            tBoxContent[3] = audioFileTagContent.Tag.Album;
                        if (cBoxState[4] != true)
                            tBoxContent[4] = audioFileTagContent.Tag.Year.ToString();
                        if (cBoxState[5] != true)
                            tBoxContent[5] = audioFileTagContent.Tag.Track.ToString();
                        if (cBoxState[6] != true)
                        {
                            foreach (string genre in audioFileTagContent.Tag.Genres)
                            {
                                tBoxContent[6] += genre + ";";
                            }
                        }
                        iMainForm.setTextBoxesContent(tBoxContent);
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

        //Clears all text from the Main Form textboxs that are unchecked
        public void clearFormAttributes(IMainForm iMainForm)
        {
            bool[] cBoxesState = iMainForm.getCheckBoxes();
            string[] tBoxContent = iMainForm.getTextBoxesContent();

            if (cBoxesState[0] != true) //Title
                tBoxContent[0] = "";
            if (cBoxesState[1] != true) //Album Artist
                tBoxContent[1] = "";
            if (cBoxesState[2] != true) //Contributing Artitst(s)
                tBoxContent[2] = "";
            if (cBoxesState[3] != true) //Album name
                tBoxContent[3] = "";
            if (cBoxesState[4] != true) //Year
                tBoxContent[4] = "";
            if (cBoxesState[5] != true) //Track number
                tBoxContent[5] = "";
            if (cBoxesState[6] != true) //Genre(s)
                tBoxContent[6] = "";

            iMainForm.setTextBoxesContent(tBoxContent);
        }

        //Checkes the form of the MainWindow for textboxes that contain null values
        public string formChecker(TagLib.File audioFileTagContent, IMainForm iMainForm)
        {
            IVerify iVerifyForm = new Verify();
            string[] tBoxContent = iMainForm.getTextBoxesContent();

            this.UserDecision = null;

            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[0], audioFileTagContent.Tag.Title);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[1], audioFileTagContent.Tag.AlbumArtists);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[2], audioFileTagContent.Tag.Performers);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[3], audioFileTagContent.Tag.Album);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[4], audioFileTagContent.Tag.Year.ToString());
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[5], audioFileTagContent.Tag.Track.ToString());
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[6], audioFileTagContent.Tag.Genres);

            return this.UserDecision;
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
