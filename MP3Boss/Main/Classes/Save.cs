using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MP3Boss
{
    public class Save : ISave
    {
        #region Save Manager helper methods
        //Returns the tag details to be saved by the saveTagChanges() method
        private string getTagToSave(string texboxtContent, string mp3Tags, string sender)
        {
            if (texboxtContent != mp3Tags)
                return texboxtContent;
            else
                return mp3Tags;
        }
        private string[] getTagToSave(List<string> textboxContent, string[] mp3Tags, string sender)
        {
            //List<string> list = new List<string>();
            bool equalStrings = false;

            if ((textboxContent == null || textboxContent.Count == 0) && mp3Tags != null)
                return textboxContent.ToArray();

            if ((textboxContent != null && textboxContent.Count != 0) && (mp3Tags != null && mp3Tags.Length != 0))
                equalStrings = Enumerable.SequenceEqual(mp3Tags, textboxContent);

            //Copy user's changes to tag
            if (equalStrings == false)
                return textboxContent.ToArray();
            else
                return mp3Tags;
        }
        private uint getTagToSave(string textboxContent, uint mp3Tags, string sender)
        {
            uint value;
            if (textboxContent == "")
                return 0;
            else if (uint.TryParse(textboxContent, out value))
            {
                return value;
            }
            else
            {
                MessageBox.Show("Invalid value: " + textboxContent + " \nEntered at: " + sender, "Error!");
                return mp3Tags;
            }
        }

        //Sets status label on form to indicate the status of the selected operation
        private void statusSet(IMainForm iMainForm)
        {
            if (this.successfullTagSave || this.successfullMP3Filesave)
                iMainForm.StatusLabel = "Done.";
            else
                iMainForm.StatusLabel = "Incomplete.";
        }
        #endregion

        //Determines the amount of files affected by the changes and saves the changes
        public void saveManager(bool applyToAll, bool autoNext, int format, IMainForm iMainForm)
        {
            firstSave = true;
            IFormManager iManageForm = new FormManager();
            IFileManager iManageFiles = null;
            TagLib.File mp3TagContent = null;
            int loopEnd = 0;
            int index = 0;
            int originalIndex = 0;

            //Variables used for renaming of files
            string originalFileName = null;
            string newFileName = null;

            int arrayLength = iMainForm.AudioFiles.Count;

            //Check if changes should be applied to all MP3 mp3Files
            if (arrayLength != 0)
            {
                loopEnd = arrayLength;
                index = iMainForm.CurrentIndex;
                originalIndex = index;

                if (applyToAll == false)
                    loopEnd = index + 1;

                #region Try to save
                try
                {
                    #region Save Changes
                    for (; index < loopEnd; index++)
                    {
                        mp3TagContent = TagLib.File.Create(iMainForm.AudioFiles[index]);

                        //Sets the forms attributes only if it is not the first save (ie. currently not in loop)
                        if (firstSave == false)
                            iManageForm.setFormAttributes(iMainForm.AudioFiles[index], iMainForm);

                        //Calls the formChecker() only if the user has not selected to "Continue" in the message dialog
                        if (iManageForm.UserDecision != "Continue")
                            iManageForm.UserDecision = iManageForm.formChecker(mp3TagContent, iMainForm);

                        //Saves all requested changes only if there are items in the listView, and user's decision is "null" or "Continue"
                        if (arrayLength != 0 && (iManageForm.UserDecision == null || iManageForm.UserDecision == "Continue"))
                        {
                            originalFileName = iMainForm.AudioFiles[index];

                            this.saveTagChanges(mp3TagContent, iMainForm.getComboBoxesContent());
                            newFileName = saveFormatToString(iMainForm.AudioFiles, index, mp3TagContent, format);
                            iManageFiles = new FileManager();
                            this.successfullMP3Filesave = iManageFiles.renameAudioFile(originalFileName, newFileName);

                            //Check if reached end of mp3Files list
                            if (applyToAll == true && originalIndex != 0 && index == (arrayLength - 1))
                            {
                                index = -1;
                                loopEnd = originalIndex;
                            }
                        }
                        else if (iManageForm.UserDecision == "Yes")
                        {
                            this.firstSave = true;
                            iMainForm.CurrentIndex = index;
                            break;
                        }
                        else if (iManageForm.UserDecision == "Skip")
                            this.firstSave = false;

                        if (applyToAll == true)
                            firstSave = false;
                    }
                    #endregion

                    #region Update ListView
                    if (applyToAll == true && (iManageForm.UserDecision == null || iManageForm.UserDecision == "Continue"))
                    {
                        iMainForm.CurrentIndex = index - 1;
                        iManageForm.refreshForm(iMainForm, true);
                    }
                    else if (applyToAll == false && (iManageForm.UserDecision == null || iManageForm.UserDecision == "Continue"))
                    {
                        iManageForm.refreshForm(iMainForm);
                    }
                    #endregion

                    this.statusSet(iMainForm);

                    #region Go to next file
                    if ((autoNext == true || iManageForm.UserDecision == "Skip") && index < iMainForm.AudioFiles.Count)
                    {
                        iMainForm.CurrentIndex = index;
                        iManageForm.setFormAttributes(iMainForm.AudioFiles[iMainForm.CurrentIndex], iMainForm);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured while trying to save the changes made.", "Warning!");
                    throw ex;
                }
                #endregion
            }
        }

        #region Major Save Manager helper methods
        //Saves changes to tags of mp3 files
        private void saveTagChanges(TagLib.File mp3TagContent, formComboBoxes tBoxContents)
        {
            mp3TagContent.Tag.Title = getTagToSave(tBoxContents.title, mp3TagContent.Tag.Title, "Title");
            mp3TagContent.Tag.AlbumArtists[0] = getTagToSave(tBoxContents.artistName, mp3TagContent.Tag.AlbumArtists[0], "Album Artist");
            mp3TagContent.Tag.Performers = (getTagToSave(tBoxContents.contributingArtists, mp3TagContent.Tag.Performers, "Contributing Artist(s)")).ToArray();
            mp3TagContent.Tag.Album = getTagToSave(tBoxContents.albumName, mp3TagContent.Tag.Album, "Album");
            mp3TagContent.Tag.Year = getTagToSave(tBoxContents.songYear, mp3TagContent.Tag.Year, "Year");
            mp3TagContent.Tag.Track = getTagToSave(tBoxContents.trackNo, mp3TagContent.Tag.Track, "TrackNo");
            mp3TagContent.Tag.Genres = getTagToSave(tBoxContents.songGenre, mp3TagContent.Tag.Genres, "Genre(s)");

            mp3TagContent.Save();

            successfullTagSave = true;
        }

        //Updates the MP3Files string array according to changes made by the user
        private string saveFormatToString(List<string> audioFiles, int index, TagLib.File audioTagContent, int format)
        {
            string title = audioTagContent.Tag.Title;
            uint track = audioTagContent.Tag.Track;
            string artist = audioTagContent.Tag.FirstAlbumArtist;

            string filePath = audioFiles[index];
            string fileDirectoryPath = audioFiles[index].Substring(0, audioFiles[index].LastIndexOf('\\') + 1);

            string validFilenameFormat = @"^[\w\-.\(\)\[\]\s]+$";
            string invalidFilenameChars = @"[^\w\-.\(\)\s]+";

            string formattedFileName = null;

            switch (format)
            {
                case 1: //#. Title - Artist     format
                    {
                        formattedFileName =
                            (track < 10 ? "0" : "") + track + ". " +
                            title + " - " + artist +
                            System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 2: //#. Artist - Title     format
                    {
                        formattedFileName =
                            (track < 10 ? "0" : "") + track + ". " +
                            artist + " - " + title +
                            System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 3: //Artist - Title    format
                    {
                        formattedFileName =
                            artist + " - " + title +
                            System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 4: //#. Title      format
                    {
                        formattedFileName =
                            (track < 10 ? "0" : "") + track + ". " +
                            title + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 5: //Title - Artist      format
                    {
                        formattedFileName =
                            title + " - " +
                            artist + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                default:
                    break;
            }

            DialogResult result = default(DialogResult);
            if (formattedFileName != null)
            {
                if (Regex.IsMatch(formattedFileName, validFilenameFormat))
                    audioFiles[index] = fileDirectoryPath + formattedFileName;
                else
                {
                    result = MessageBox.Show("Invalid charachters in potential filename: " + formattedFileName +
                        "\nRemove invalid characters?",
                        "Error!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        formattedFileName = Regex.Replace(formattedFileName, invalidFilenameChars, "");

                        audioFiles[index] = fileDirectoryPath + formattedFileName;
                    }
                }
            }
            return audioFiles[index];
        }
        #endregion

        //Finds all strings that matches user's "find" input,  and replaces it with the user's "replace" input
        public void searchAndReplace(string find, string replace, List<string> mp3Files, int currentIndex, bool searchAll)
        {
            TagLib.File tagFile = null;
            int loopEnd = 0;
            int index = 0;

            if (mp3Files != null && mp3Files.Count != 0 && currentIndex >= 0)
            {
                loopEnd = mp3Files.Count;
                index = currentIndex;

                if (searchAll == false)
                    loopEnd = index + 1;
                else if (searchAll == true)
                    index = 0;

                for (; index < loopEnd; index++)
                {
                    tagFile = TagLib.File.Create(mp3Files[index]);

                    //Search and replace in the title of the song
                    tagFile.Tag.Title = tagFile.Tag.Title.Replace(find, replace);

                    string[] tempArray = null;

                    //Search and replace in the Album Artist tag of the song
                    foreach (string item in tagFile.Tag.AlbumArtists)
                    {
                        int i = 0;
                        tempArray = tagFile.Tag.AlbumArtists;
                        tempArray[i] = item.Replace(find, replace);
                        tagFile.Tag.AlbumArtists = tempArray;
                        ++i;
                    }

                    //Search and replace in the Contributing Artists tag of the song
                    foreach (string item in tagFile.Tag.Performers)
                    {
                        int i = 0;
                        tempArray = tagFile.Tag.Performers;
                        tempArray[i] = item.Replace(find, replace);
                        tagFile.Tag.Performers = tempArray;
                        ++i;
                    }

                    //Search and replace in the Album tag of the song
                    tagFile.Tag.Album = tagFile.Tag.Album.Replace(find, replace);

                    //Search and replace in the Genre tag of the song
                    foreach (string item in tagFile.Tag.Genres)
                    {
                        int i = 0;
                        tempArray = tagFile.Tag.Genres;
                        tempArray[i] = item.Replace(find, replace);
                        tagFile.Tag.Genres = tempArray;
                        ++i;
                    }

                    //Save changes to the audio file
                    tagFile.Save();
                }
            }
            else
                MessageBox.Show("No files found.", "Error!");
        }

        private bool successfullTagSave = false;
        private bool successfullMP3Filesave = false;
        private bool firstSave = false;
    }
}
