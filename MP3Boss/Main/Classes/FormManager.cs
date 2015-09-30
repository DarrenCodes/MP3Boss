using System.Windows.Forms;
using System;

namespace MP3Boss
{
    public class FormManager : IFormManager
    {
        //Public method used to manage the searching and loading of files onto the ListView
        public void loadFilesOntoForm(IMainForm iMainForm, bool isDeepScan)
        {
            IFileManager iManageFiles = new FileManager();
            if (iMainForm.DirectoryIsSet == false)
            {
                iMainForm.MP3Files = iManageFiles.getMP3Files(iMainForm.DirectoryIsSet, isDeepScan);

                iMainForm.DirectoryIsSet = (iMainForm.MP3Files != null && iMainForm.MP3Files.Length != 0) ? true : false;
            }

            this.populateListView(iMainForm);

            TagLib.File mp3TagContent = null;

            if (iMainForm.MP3Files != null)
                mp3TagContent = TagLib.File.Create(iMainForm.MP3Files[iMainForm.CurrentIndex]);

            if (iMainForm.MP3Files != null && iMainForm.MP3Files.Length != 0)
                setFormAttributes(mp3TagContent, iMainForm);
        }

        #region loadFilesOntoForm helper methods
        //Populates ListView with shortened strings from mp3Files string array (file names only)
        private void populateListView(IMainForm iMainForm)
        {
            iMainForm.ListViewMP3s.Items.Clear();

            if (iMainForm.MP3Files != null)
            {
                //Adds list of files to List View element in GUI
                foreach (string mp3File in iMainForm.MP3Files)
                {
                    int startPosition = mp3File.LastIndexOf('\\') + 1;
                    int length = mp3File.LastIndexOf('.') - startPosition;
                    iMainForm.ListViewMP3s.Items.Add(mp3File.Substring(startPosition, length));
                }
            }
        }
        #endregion

        //Updates each item in the listview where changes were made
        public void updateListView(IMainForm iMainForm, int index)
        {
            int startPosition = iMainForm.MP3Files[index].LastIndexOf('\\') + 1;
            int length = (iMainForm.MP3Files[index].LastIndexOf('.')) - startPosition;
            iMainForm.ListViewMP3s.Items[index].Text = iMainForm.MP3Files[index].Substring(startPosition, length);

            iMainForm.ListViewMP3s.Refresh();
        }

        //Public method used to set the form attributes according to the TagLib.FIle object passed
        public void setFormAttributes(TagLib.File mp3TagContent, IMainForm iMainForm)
        {
            bool[] cBoxState = iMainForm.getCheckBoxes();
            string[] tBoxContent = new string[7];

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

        //Clears all text from the Main Form textboxs that are unchecked
        public void clearFormAttributes(IMainForm iMainForm)
        {
            bool[] cBoxesState = iMainForm.getCheckBoxes();
            string[] tBoxContent = iMainForm.getTextBoxesContent();

            if (cBoxesState[0] != true) //Title
                tBoxContent[0] = null;
            if (cBoxesState[1] != true) //Album Artist
                tBoxContent[1] = null;
            if (cBoxesState[2] != true) //Contributing Artitst(s)
                tBoxContent[2] = null;
            if (cBoxesState[3] != true) //Album name
                tBoxContent[3] = null;
            if (cBoxesState[4] != true) //Year
                tBoxContent[4] = null;
            if (cBoxesState[5] != true) //Track number
                tBoxContent[5] = null;
            if (cBoxesState[6] != true) //Genre(s)
                tBoxContent[6] = null;

            iMainForm.setTextBoxesContent(tBoxContent);
        }

        //Checkes the form of the MainWindow for textboxes that contain null values
        public DialogResult formChecker(TagLib.File mp3TagContent, IMainForm iMainForm)
        {
            IVerify iVerifyForm = new Verify();
            string[] tBoxContent = iMainForm.getTextBoxesContent();

            this.UserDecision = default(DialogResult);

            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[0], mp3TagContent.Tag.Title);
            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[1], mp3TagContent.Tag.AlbumArtists);
            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[2], mp3TagContent.Tag.Performers);
            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[3], mp3TagContent.Tag.Album);
            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[4], mp3TagContent.Tag.Year.ToString());
            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[5], mp3TagContent.Tag.Track.ToString());
            if (this.UserDecision == default(DialogResult))
                this.UserDecision = iVerifyForm.nullTagChecker(tBoxContent[6], mp3TagContent.Tag.Genres);

            return this.UserDecision;
        }

        #region Variables and Properties
        static DialogResult userDecision = default(DialogResult);
        public DialogResult UserDecision
        {
            get { return userDecision; }
            set { userDecision = value; }
        }
        #endregion
    }
}
