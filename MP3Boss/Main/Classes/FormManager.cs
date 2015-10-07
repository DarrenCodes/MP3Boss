using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace MP3Boss
{
    public class FormManager : IFormManager
    {
        //Populates ListView with shortened strings from mp3Files string array (file names only)
        public void refreshForm(IMainForm iMainForm, bool applyToAll = false)
        {
            List<string> mp3Files = iMainForm.MP3Files;
            if (mp3Files != null && mp3Files.Count != 0)
            {
                int currentIndex = iMainForm.CurrentIndex;
                ListView listViewMP3s = iMainForm.ListViewMP3s;
                int startPosition = 0;
                int length = 0;

                if (applyToAll == true)
                {
                    listViewMP3s.Items.Clear();
                    //Adds list of files to List View element in GUI
                    foreach (string mp3File in mp3Files)
                    {
                        startPosition = mp3File.LastIndexOf('\\') + 1;
                        length = mp3File.LastIndexOf('.') - startPosition;
                        listViewMP3s.Items.Add(mp3File.Substring(startPosition, length));
                    }
                }
                else if (applyToAll == false && (mp3Files != null && mp3Files.Count != 0))
                {
                    startPosition = mp3Files[currentIndex].LastIndexOf('\\') + 1;
                    length = mp3Files[currentIndex].LastIndexOf('.') - startPosition;
                    listViewMP3s.Items[currentIndex].Text = mp3Files[currentIndex].Substring(startPosition, length);
                }

                if (iMainForm.FormAttributesAreSet == false)
                    this.setFormAttributes(iMainForm.MP3Files[currentIndex], iMainForm);

                if (iMainForm.ComponentsAreEnabled == false)
                    iMainForm.manageFormComponents(true);

                iMainForm.ItemsCountLabel = mp3Files.Count.ToString();
            }
        }

        //Public method used to set the form attributes according to the TagLib.FIle object passed
        public void setFormAttributes(string path, IMainForm iMainForm)
        {
            TagLib.File mp3TagContent = null;
            bool[] cBoxState = null;
            string[] tBoxContent = null;

            if (path != null && path.Length != 0)
            {
                mp3TagContent = TagLib.File.Create(path);
                if (mp3TagContent != null)
                {
                    cBoxState = iMainForm.getCheckBoxes();
                    tBoxContent = new string[7];

                    //Assigning tag properties to designated textboxes
                    if (cBoxState[0] != true)
                        tBoxContent[0] = mp3TagContent.Tag.Title;
                    if (cBoxState[1] != true)
                        tBoxContent[1] = mp3TagContent.Tag.FirstAlbumArtist;
                    //Loop for finding & displaying all contributing artists from MP3 file (array)
                    if (cBoxState[2] != true)
                    {
                        foreach (string performers in mp3TagContent.Tag.Performers)
                        {
                            tBoxContent[2] += performers + ";";
                        }
                    }
                    if (cBoxState[3] != true)
                        tBoxContent[3] = mp3TagContent.Tag.Album;
                    if (cBoxState[4] != true)
                        tBoxContent[4] = mp3TagContent.Tag.Year.ToString();
                    if (cBoxState[5] != true)
                        tBoxContent[5] = mp3TagContent.Tag.Track.ToString();
                    if (cBoxState[6] != true)
                    {
                        foreach (string genre in mp3TagContent.Tag.Genres)
                        {
                            tBoxContent[6] += genre + ";";
                        }
                    }
                    iMainForm.setTextBoxesContent(tBoxContent);
                }
            }
            else
                MessageBox.Show("No path selected!", "Error!");

            iMainForm.FilePathLabel = path;
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
        public string formChecker(TagLib.File mp3TagContent, IMainForm iMainForm)
        {
            IVerify iVerifyForm = new Verify();
            string[] tBoxContent = iMainForm.getTextBoxesContent();

            this.UserDecision = null;

            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[0], mp3TagContent.Tag.Title);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[1], mp3TagContent.Tag.AlbumArtists);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[2], mp3TagContent.Tag.Performers);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[3], mp3TagContent.Tag.Album);
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[4], mp3TagContent.Tag.Year.ToString());
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[5], mp3TagContent.Tag.Track.ToString());
            if (this.UserDecision == null)
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[6], mp3TagContent.Tag.Genres);

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
