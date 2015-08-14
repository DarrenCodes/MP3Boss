using System.Linq;
using System.IO;
using System.Windows.Forms;
using System;

namespace MP3Boss
{
    class TagAndFormTools
    {
        internal void populateListView(FormMP3Boss obj)
        {
            obj.listViewMP3s.Items.Clear();

            if (obj.fileScanIsDeep == false)
                obj.files = Directory.GetFiles(obj.fBDialogLoadMP3s.SelectedPath, "*.mp3"); //Loads mp3 files from selected path
            else if (obj.fileScanIsDeep == true)
                obj.files = Directory.GetFiles(obj.fBDialogLoadMP3s.SelectedPath, "*.mp3", SearchOption.AllDirectories); //Loads all mp3 files from selected path and subdirectories

            if (obj.files != null)
            {
                //Adds list of files to List View element in GUI
                foreach (string file in obj.files)
                {
                    obj.listViewMP3s.Items.Add(file.Substring(file.LastIndexOf('\\') + 1), file.LastIndexOf('.'));
                }
            }
        }

        //Clear all text from the Main Form textboxs
        internal void clearFormAttributes(FormMP3Boss obj)
        {
            if (obj.cBoxTitle.Checked != true)
                obj.tBoxTitle.Text = null;
            if (obj.cBoxAlbumArtist.Checked != true)
                obj.tBoxAlbumArtist.Text = null;
            if (obj.cBoxContArtists.Checked != true)
                obj.tBoxContArtists.Text = null;
            if (obj.cBoxAlbum.Checked != true)
                obj.tBoxAlbum.Text = null;
            if (obj.cBoxYear.Checked != true)
                obj.tBoxYear.Text = null;
            if (obj.cBoxTrackNo.Checked != true)
                obj.tBoxTrackNo.Text = null;
            if (obj.cBoxGenre.Checked != true)
                obj.tBoxGenre.Text = null;
        }

        //Set the attributes of the song according to the selected item in its respective Main Form textboxes
        internal void setFormAttributes(string path, FormMP3Boss obj)
        {
            TagLib.File file = null;

            try
            {
                file = TagLib.File.Create(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }

            clearFormAttributes(obj);

            //Instantiate object with address of selected MP3 file
            if (obj.cBoxTitle.Checked != true)
                obj.tBoxTitle.Text = file.Tag.Title;
            if (obj.cBoxAlbumArtist.Checked != true)
                obj.tBoxAlbumArtist.Text = file.Tag.FirstAlbumArtist;
            //Loop for finding & displaying all contributing artists from MP3 file (array)
            if (obj.cBoxContArtists.Checked != true)
            {
                for (int i = 0; i < file.Tag.Performers.Length; i++)
                {
                    if (i == (file.Tag.Performers.Length - 1))
                    {
                        obj.tBoxContArtists.Text += file.Tag.Performers[i];
                    }
                    else
                        obj.tBoxContArtists.Text += file.Tag.Performers[i] + ";";
                }
            }
            if (obj.cBoxAlbum.Checked != true)
                obj.tBoxAlbum.Text = file.Tag.Album;
            if (obj.cBoxYear.Checked != true)
                obj.tBoxYear.Text = file.Tag.Year.ToString();
            if (obj.cBoxTrackNo.Checked != true)
                obj.tBoxTrackNo.Text = file.Tag.Track.ToString();
            if (obj.cBoxGenre.Checked != true)
            {
                for (int i = 0; i < file.Tag.Genres.Length; i++)
                {
                    if (i == (file.Tag.Genres.Length - 1))
                    {
                        obj.tBoxGenre.Text += file.Tag.Genres[i];
                    }
                    else
                        obj.tBoxGenre.Text += file.Tag.Genres[i] + ";";
                }
            }
        }

        //Prompts the user to check the tags loaded in the form or to ignore
        private void checkFormMessage(FormMP3Boss obj)
        {
            DialogResult dialogResult = MessageBox.Show("All fields not filled. Fill now? \n(Selecting No will re-format using existing tags.)", "Important Message", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.No)
            {
                obj.formIsCompletedFlag = true;
                obj.skipRestFlag = true;
            }
            if (dialogResult == DialogResult.Yes)
            {
                obj.userFormat = obj.comboBoxFormat.SelectedIndex;
                obj.comboBoxFormat.SelectedIndex = 0;
                obj.selectedIndex = obj.interruptedIndex;
                obj.formIsCompletedFlag = false;
                obj.skipRestFlag = true;
            }
            if (dialogResult == DialogResult.Cancel)
            {
                obj.formIsCompletedFlag = false;
                obj.skipRestFlag = true;
            }
        }

        //Checks the textboxes to see if the "checkFormMessage" should be called
        private void nullTagChecker(string textBox, string fileTag, FormMP3Boss obj)
        {
            bool isNullTag;

            if (fileTag == null)
                fileTag = "";

            if (textBox == fileTag
                && (fileTag == ""))
                isNullTag = true;
            else
                isNullTag = false;

            if (!obj.skipRestFlag && isNullTag)
            {
                checkFormMessage(obj);
            }
        }
        private void nullTageChecker(string textBox, string[] fileTag, FormMP3Boss obj)
        {
            bool isNullTag;

            string[] contArtistArr = null;

            if (textBox != "")
                contArtistArr = textBox.Split(';'); //Split user entered string into array

            if (contArtistArr == null
                && (fileTag == null || fileTag.Length == 0))
                isNullTag = true;
            else
                isNullTag = false;

            if (!obj.skipRestFlag && isNullTag)
            {
                checkFormMessage(obj);
            }
        }

        //Calls "nullTagChecker" to verify that the current tags are not null
        internal void formChecker(string path, FormMP3Boss obj)
        {
            obj.formIsCompletedFlag = true;
            obj.skipRestFlag = false;

            TagLib.File file = TagLib.File.Create(path);

            nullTagChecker(obj.tBoxTitle.Text, file.Tag.Title, obj);
            nullTagChecker(obj.tBoxAlbumArtist.Text, file.Tag.FirstAlbumArtist, obj);
            nullTageChecker(obj.tBoxContArtists.Text, file.Tag.Performers, obj);
            nullTagChecker(obj.tBoxAlbum.Text, file.Tag.Album, obj);
            nullTagChecker(obj.tBoxYear.Text, file.Tag.Year.ToString(), obj);
            nullTagChecker(obj.tBoxTrackNo.Text, file.Tag.Track.ToString(), obj);
            nullTageChecker(obj.tBoxGenre.Text, file.Tag.Genres, obj);

            if (obj.formIsCompletedFlag)
                saveChangesToFile(path, obj, file);
        }

        private void saveChangesToFile(string path, FormMP3Boss obj, TagLib.File file)
        {
            if (obj.tBoxTitle.Text != file.Tag.Title)
                file.Tag.Title = obj.tBoxTitle.Text;

            if (obj.tBoxAlbumArtist.Text != file.Tag.FirstAlbumArtist)
            {
                file.Tag.AlbumArtists = null;
                file.Tag.AlbumArtists = new[] { obj.tBoxAlbumArtist.Text };
            }

            string[] contArtistArr = null;
            if (obj.tBoxContArtists.Text != "" && obj.tBoxContArtists.Text != null)
                contArtistArr = obj.tBoxContArtists.Text.Split(';'); //Split user entered string into array

            bool contEqual = false;
            if (contArtistArr != null && file.Tag.Performers.Length != 0)
                contEqual = Enumerable.SequenceEqual(file.Tag.Performers, contArtistArr);

            //Copy user's changes to tag
            if (contEqual == false)
            {
                file.Tag.Performers = null; //Clear tag (sorts out bug)
                file.Tag.Performers = contArtistArr;
            }

            if (obj.tBoxAlbum.Text != file.Tag.Album)
                file.Tag.Album = obj.tBoxAlbum.Text;

            if (obj.tBoxYear.Text != file.Tag.Year.ToString())
                file.Tag.Year = uint.Parse(obj.tBoxYear.Text);

            if (obj.tBoxTrackNo.Text != file.Tag.Track.ToString())
                file.Tag.Track = uint.Parse(obj.tBoxTrackNo.Text);

            string[] genre = obj.tBoxGenre.Text.Split(';'); //Split user entered string into array
            bool genreEqual = Enumerable.SequenceEqual(file.Tag.Genres, genre); //Check if user changed field

            //Copy user's changes to tag
            if (genreEqual == false)
            {
                file.Tag.Genres = null; //Clear tag (sorts out bug)
                file.Tag.Genres = genre;
            }

            try
            {
                file.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Important Message");
            }


            switch (obj.comboBoxFormat.SelectedIndex)
            {
                case 1: //#. Title - Artist     format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Track + ". " +
                            file.Tag.Title + " - " +
                            file.Tag.FirstAlbumArtist + ".mp3";

                        renameFiles(path, newFileName);

                        break;
                    }
                case 2: //#. Artist - Title     format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Track + ". " +
                            file.Tag.FirstAlbumArtist + " - " +
                            file.Tag.Title + ".mp3";

                        renameFiles(path, newFileName);

                        break;
                    }
                case 3: //Artist - Title    format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.FirstAlbumArtist + " - " +
                            file.Tag.Title + ".mp3";

                        renameFiles(path, newFileName);

                        break;
                    }
                case 4: //#. Title      format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Track + ". " +
                            file.Tag.Title + ".mp3";

                        renameFiles(path, newFileName);

                        break;
                    }
                case 5: //Title - Artist      format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Title + " - " +
                            file.Tag.FirstAlbumArtist + ".mp3";

                        renameFiles(path, newFileName);

                        break;
                    }
                default:
                    break;
            }
        }
        
        //Renames the files on the storage device
        private void renameFiles(string originalPath, string newFileName)
        {
            try
            {
                System.IO.File.Move(originalPath, newFileName);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file at:" + originalPath + " was not found.", "Error!");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

    }
}
