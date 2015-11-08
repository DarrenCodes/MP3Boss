using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using MP3Boss.Source.Common.Form.Containers;
using MP3Boss.Source.Classes.File;
using MP3Boss.Source.Classes.Database;
using MP3Boss.Source.Classes.Validation;
using MP3Boss.Source.Interfaces.Validate;
using MP3Boss.Source.Interfaces.Form;
using MP3Boss.Source.Interfaces.File;
using MP3Boss.Source.Interfaces.Database;

namespace MP3Boss.Source.Classes.Form
{
    public class FormManager : IFormManager
    {
        private IGUI guiMain;

        public FormManager(IGUI gui)
        {
            this.guiMain = gui;
        }

        public void fillFileList(string[] dropedFiles, ListView listViewAudioFiles)
        {
            IAudioFile file = new AudioFile();

            file.getAudioFiles(dropedFiles, listViewAudioFiles, this.audioFilesList, this.audioFilesPathDictionary);

            if (this.firstDragAndDrop)
            {
                if (listViewAudioFiles.Items.Count > 0)
                {
                    string path = audioFilesList[guiMain.CurrentIndex];
                    this.setFormAttributes(path);
                    guiMain.FilePathLabel = path;
                }
            }

            guiMain.manageFormComponents(true);

            this.firstDragAndDrop = false;
        }

        public void refreshListView(ListView listViewAudioFiles)
        {
            listViewAudioFiles.Items.Clear();
            foreach (string path in audioFilesList)
            {
                listViewAudioFiles.Items.Add(System.IO.Path.GetFileName(path));
            }

            this.setFormAttributes(this.audioFilesList[0]);
            guiMain.manageFormComponents(true);
            guiMain.ItemsCountLabel = listViewAudioFiles.Items.Count.ToString();
        }

        public void saveToFile(bool applyToAll, bool autoNext, int format, ListView listViewAudioFiles)
        {
            FormContent.ComboBoxesContent editedTags;

            int i = guiMain.CurrentIndex;
            bool firstSave = true;
            IAudioFile file = new AudioFile();
            int loopEnd = 0;
            int originalIndex = 0;
            string originalPath = "";

            int listLength = listViewAudioFiles.Items.Count;
            string filePath = "";

            if (listLength > 0)
            {
                string userDecision = null;

                originalIndex = i;

                if (applyToAll == true)
                    loopEnd = listLength;
                else
                    loopEnd = i + 1;

                #region Try to save
                try
                {
                    #region Save Changes
                    for (; i < loopEnd; i++)
                    {
                        filePath = audioFilesList[i];

                        if (firstSave == false)
                            this.setFormAttributes(filePath);

                        editedTags = guiMain.getComboBoxesContent();

                        if (userDecision != "Continue")
                            userDecision = this.formChecker(editedTags);

                        if (listLength != 0 && (userDecision == null || userDecision == "Continue"))
                        {
                            originalPath = filePath;

                            file.write(filePath, editedTags);
                            filePath = file.rename(filePath, editedTags, format);
                            listViewAudioFiles.Items[i].Text = System.IO.Path.GetFileName(filePath);
                            audioFilesList[i] = filePath;
                            this.updateAudioFilesDictionary(audioFilesPathDictionary, originalPath, audioFilesList[i]);

                            firstSave = false;

                            if (applyToAll == true && originalIndex != 0 && i == (listLength - 1))
                            {
                                i = -1;
                                loopEnd = originalIndex;
                            }
                        }
                        else if (userDecision == "Yes")
                        {
                            firstSave = true;
                            break;
                        }
                        else if (userDecision == "Skip")
                            firstSave = false;

                        if (applyToAll == true)
                            firstSave = false;

                        guiMain.StatusLabel = "Done.";
                    }
                    if (i >= audioFilesList.Count)
                    {
                        guiMain.CurrentIndex = 0;
                        this.loadFileTags(0);
                    }
                    #endregion

                    #region Go to next file
                    if ((autoNext == true || userDecision == "Skip") && i < listLength)
                    {
                        this.setFormAttributes(this.audioFilesList[i]);
                        ++guiMain.CurrentIndex;
                    }
                    #endregion
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("The file was not found.", "Warning!");
                }
                catch (IOException ex)
                {
                    MessageBox.Show("An unexpected error occured while trying to save the changes made.", "Warning!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. Sorry.", "Warning!");
                }
                #endregion
            }
        }

        private void updateAudioFilesDictionary(Dictionary<int, string> audioFilesPathDictionary, string oldPath, string newPath)
        {
            int oldPathDictionaryIndex = oldPath.GetHashCode();

            audioFilesPathDictionary.Remove(oldPathDictionaryIndex);

            int newPathDictionaryIndex = newPath.GetHashCode();

            audioFilesPathDictionary.Add(newPathDictionaryIndex, newPath);
        }

        private string fileChooserGetPath()
        {
            string path = "";
            OpenFileDialog findFile = new OpenFileDialog();
            findFile.Filter = "SQLite Files (.sqlite)|*.sqlite";

            DialogResult result = findFile.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                path = findFile.FileName;
            }

            return path;
        }

        private bool checkDBFileAndSave()
        {
            if (!System.IO.File.Exists(Properties.Settings.Default.DatabasePath))
            {
                string path = this.fileChooserGetPath();
                if (System.IO.File.Exists(path))
                {
                    Properties.Settings.Default.DatabasePath = path;
                    Properties.Settings.Default.Save();
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private void loadTagArt(PictureBox tagArtBox, string filePath)
        {
            try
            {
                TagLib.File tagObject = TagLib.File.Create(filePath);
                MemoryStream ms = new MemoryStream(tagObject.Tag.Pictures[0].Data.Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                tagArtBox.Image = image;
            }
            catch (IndexOutOfRangeException)
            {
                tagArtBox.Image = null;
            }
        }

        public void loadFileTags(int index)
        {
            this.setFormAttributes(this.audioFilesList[index]);
        }

        private void setFormAttributes(string filePath)
        {
            IAudioFile file = null;

            if (file == null)
                file = new AudioFile();

            this.guiMain.setComboBoxesContent(file.read(filePath));

            this.loadTagArt(guiMain.TagArt, filePath);
            guiMain.FilePathLabel = filePath;
        }

        public string formChecker(FormContent.ComboBoxesContent audioFileTags)
        {
            IVerify iVerifyForm = new Verify();
            string userDecision = null;

            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.title);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.artistName);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.contributingArtists);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.albumName);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.songGenre);

            return userDecision;
        }

        public void manageSuggestions()
        {
            this.checkDBFileAndSave();

            IDatabaseSuggest suggestions = new TagSuggest();
            FormContent.ComboBoxesContent currentComboBoxContent = guiMain.getComboBoxesContent();

            List<FormContent.ComboBoxesContent> suggestionResults = suggestions.getSuggestions(currentComboBoxContent);

            if (suggestionResults.Count != 0)
                guiMain.setComboBoxesContent(suggestionResults);
        }

        public void searchAndReplace(string find, string replace, bool applyToAll)
        {
            IAudioFile file = null;

            if (file == null)
                file = new AudioFile();

            if (applyToAll)
                file.searchAndReplace(this.audioFilesList, find, replace);
            else
                file.searchAndReplace(this.audioFilesList[guiMain.CurrentIndex], find, replace);

            this.loadFileTags(guiMain.CurrentIndex);
        }

        #region Variables

        private List<string> audioFilesList = new List<string>();
        public List<string> AudioFilesList
        {
            get { return audioFilesList; }
            set { audioFilesList = value; }
        }

        private Dictionary<int, string> audioFilesPathDictionary = new Dictionary<int, string>();
        public Dictionary<int, string> AudioFilesPathDictionary
        {
            get { return audioFilesPathDictionary; }
            set { audioFilesPathDictionary = value; }
        }

        private bool firstDragAndDrop = true;
        public bool FirstDragAndDrop
        {
            get { return firstDragAndDrop; }
            set { firstDragAndDrop = value; }
        }

        #endregion
    }
}
