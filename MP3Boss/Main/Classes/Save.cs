﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MP3Boss
{
    public class Save : ISave
    {
        #region Save Manager basic helper methods
        //Returns the tag details to be saved by the saveTagChanges() method
        private string getTagToSave(string texboxtContent, string mp3Tags, string sender)
        {
            if (texboxtContent != mp3Tags)
                return texboxtContent;
            else
                return mp3Tags;
        }
        private string[] getTagToSave(string textboxContent, string[] mp3Tags, string sender)
        {
            string[] array = null;
            bool equalStrings = false;

            if (textboxContent != "")
            {
                array = (textboxContent.Split(';')).Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Split user entered string into array
            }
            if (array != null && mp3Tags.Length != 0)
                equalStrings = Enumerable.SequenceEqual(mp3Tags, array);

            //Copy user's changes to tag
            if (equalStrings == false)
                return array;
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

            iManageForm.UserDecision = default(DialogResult);
            int arrayLength = iMainForm.MP3Files.Length;

            //Check if changes should be applied to all MP3 mp3Files
            if (arrayLength != 0)
            {
                #region Variables
                int loopEnd = arrayLength;
                int index = iMainForm.CurrentIndex;
                int originalIndex = index;

                TagLib.File mp3TagContent = null;

                string originalFileName = null;
                string newFileName = null;

                if (applyToAll == false)
                    loopEnd = index + 1;
                #endregion

                #region Try to save
                try
                {
                    //Attempt to save changes to all mp3Files with an interrupt variable to track last file save attempt
                    #region Save Changes
                    for (; index < loopEnd; index++)
                    {
                        mp3TagContent = TagLib.File.Create(iMainForm.MP3Files[index]);

                        if (firstSave == false)
                            iManageForm.setFormAttributes(mp3TagContent, iMainForm);

                        if (iManageForm.UserDecision != DialogResult.Abort)
                            iManageForm.UserDecision = iManageForm.formChecker(mp3TagContent, iMainForm);

                        if (arrayLength != 0 && (iManageForm.UserDecision == default(DialogResult) || iManageForm.UserDecision == DialogResult.Abort))
                        {
                            originalFileName = iMainForm.MP3Files[index];

                            this.saveTagChanges(mp3TagContent, iMainForm.getTextBoxesContent());
                            newFileName = saveFormatToString(iMainForm.MP3Files, index, mp3TagContent, format);
                            IFileManager iManageFiles = new FileManager();
                            this.successfullMP3Filesave = iManageFiles.renameMP3File(originalFileName, newFileName);

                            //Check if reached end of mp3Files list
                            if (applyToAll == true && originalIndex != 0 && index == (arrayLength - 1))
                            {
                                index = -1;
                                loopEnd = originalIndex;
                            }
                        }
                        else if (iManageForm.UserDecision == DialogResult.Retry)
                        {
                            this.firstSave = true;
                            iMainForm.CurrentIndex = index;
                            break;
                        }
                        else if (iManageForm.UserDecision == DialogResult.Ignore)
                            this.firstSave = false;

                        if (applyToAll == true)
                            firstSave = false;
                    }
                    #endregion

                    #region Update ListView
                    if (applyToAll == true && (iManageForm.UserDecision == default(DialogResult) || iManageForm.UserDecision == DialogResult.Abort))
                    {
                        iMainForm.CurrentIndex = index;
                        iMainForm.refreshForm();
                    }
                    else if (applyToAll == false && index < arrayLength && iManageForm.UserDecision != DialogResult.Retry)
                    {
                        iManageForm.updateListView(iMainForm, index - 1);
                    }
                    #endregion

                    this.statusSet(iMainForm);

                    #region Go to next file
                    if ((autoNext == true || iManageForm.UserDecision == DialogResult.Ignore) && index < iMainForm.MP3Files.Length)
                    {
                        iMainForm.CurrentIndex = index;
                        mp3TagContent = TagLib.File.Create(iMainForm.MP3Files[iMainForm.CurrentIndex]);
                        iManageForm.setFormAttributes(mp3TagContent, iMainForm);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured while trying to save the changes made.", "Warning!");
                }
                #endregion
            }
        }

        #region Major Save Manager helper methods
        //Saves changes to tags of mp3 files
        private void saveTagChanges(TagLib.File mp3TagContent, string[] tBoxContents)
        {
            mp3TagContent.Tag.Title = getTagToSave(tBoxContents[0], mp3TagContent.Tag.Title, "Title");
            mp3TagContent.Tag.AlbumArtists = getTagToSave(tBoxContents[1], mp3TagContent.Tag.AlbumArtists, "Album Artist");
            mp3TagContent.Tag.Performers = getTagToSave(tBoxContents[2], mp3TagContent.Tag.Performers, "Contributing Artist(s)");
            mp3TagContent.Tag.Album = getTagToSave(tBoxContents[3], mp3TagContent.Tag.Album, "Album");
            mp3TagContent.Tag.Year = getTagToSave(tBoxContents[4], mp3TagContent.Tag.Year, "Year");
            mp3TagContent.Tag.Track = getTagToSave(tBoxContents[5], mp3TagContent.Tag.Track, "TrackNo");
            mp3TagContent.Tag.Genres = getTagToSave(tBoxContents[6], mp3TagContent.Tag.Genres, "Genre(s)");

            mp3TagContent.Save();

            successfullTagSave = true;
        }

        //Updates the MP3Files string array according to changes made by the user
        private string saveFormatToString(string[] MP3Files, int index, TagLib.File mp3TagContent, int format)
        {
            switch (format)
            {
                case 1: //#. Title - Artist     format
                    {
                        MP3Files[index] = MP3Files[index].Substring(0, MP3Files[index].LastIndexOf('\\') + 1) +
                            (mp3TagContent.Tag.Track < 10 ? "0" : "") +
                            mp3TagContent.Tag.Track + ". " +
                            mp3TagContent.Tag.Title + " - " +
                            mp3TagContent.Tag.FirstAlbumArtist + ".mp3";

                        break;
                    }
                case 2: //#. Artist - Title     format
                    {
                        MP3Files[index] = MP3Files[index].Substring(0, MP3Files[index].LastIndexOf('\\') + 1) +
                            (mp3TagContent.Tag.Track < 10 ? "0" : "") +
                            mp3TagContent.Tag.Track + ". " +
                            mp3TagContent.Tag.FirstAlbumArtist + " - " +
                            mp3TagContent.Tag.Title + ".mp3";

                        break;
                    }
                case 3: //Artist - Title    format
                    {
                        MP3Files[index] = MP3Files[index].Substring(0, MP3Files[index].LastIndexOf('\\') + 1) +
                            mp3TagContent.Tag.FirstAlbumArtist + " - " +
                            mp3TagContent.Tag.Title + ".mp3";

                        break;
                    }
                case 4: //#. Title      format
                    {
                        MP3Files[index] = MP3Files[index].Substring(0, MP3Files[index].LastIndexOf('\\') + 1) +
                            (mp3TagContent.Tag.Track < 10 ? "0" : "") +
                            mp3TagContent.Tag.Track + ". " +
                            mp3TagContent.Tag.Title + ".mp3";

                        break;
                    }
                case 5: //Title - Artist      format
                    {
                        MP3Files[index] = MP3Files[index].Substring(0, MP3Files[index].LastIndexOf('\\') + 1) +
                            mp3TagContent.Tag.Title + " - " +
                            mp3TagContent.Tag.FirstAlbumArtist + ".mp3";

                        break;
                    }
                default:
                    break;
            }
            return MP3Files[index];
        }
        #endregion

        //Finds all strings that matches user's "find" input,  and replaces it with the user's "replace" input
        public void searchAndReplace(string find, string replace, string[] mp3Files, int currentIndex, bool searchAll)
        {
            if (mp3Files != null && mp3Files.Length != 0 && currentIndex >= 0)
            {
                int loopEnd = mp3Files.Length;
                int index = currentIndex;

                if (searchAll == false)
                    loopEnd = index + 1;
                else if (searchAll == true)
                    index = 0;

                for (; index < loopEnd; index++)
                {
                    TagLib.File tagFile = TagLib.File.Create(mp3Files[index]);

                    tagFile.Tag.Title = Regex.Replace(tagFile.Tag.Title, find, replace);

                    string[] tempArray = null;

                    foreach (string item in tagFile.Tag.AlbumArtists)
                    {
                        int i = 0;
                        tempArray = tagFile.Tag.AlbumArtists;
                        tempArray[i] = Regex.Replace(item, find, replace);
                        tagFile.Tag.AlbumArtists = tempArray;
                        ++i;
                    }

                    foreach (string item in tagFile.Tag.Performers)
                    {
                        int i = 0;
                        tempArray = tagFile.Tag.Performers;
                        tempArray[i] = Regex.Replace(item, find, replace);
                        tagFile.Tag.Performers = tempArray;
                        ++i;
                    }

                    tagFile.Tag.Album = Regex.Replace(tagFile.Tag.Album, find, replace);

                    foreach (string item in tagFile.Tag.Genres)
                    {
                        int i = 0;
                        tempArray = tagFile.Tag.Genres;
                        tempArray[i] = Regex.Replace(item, find, replace);
                        tagFile.Tag.Genres = tempArray;
                        ++i;
                    }

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
