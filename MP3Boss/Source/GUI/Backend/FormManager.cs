using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using MP3Boss.Source.File;
using MP3Boss.Source.Objects;
using MP3Boss.Source.Datastructures;
using MP3Boss.Source.Validation;
using MP3Boss.Source.Database;

namespace MP3Boss.Source.GUI.Backend
{
    public class FormManager : IFormManager
    {
        private IView guiMain;

        public FormManager(IView gui)
        {
            this.guiMain = gui;
        }

        public void FillFileList(string[] dropedFiles, ListView listViewAudioFiles)
        {
            IAudioFile file = ObjectFactory.GetAudioFileManager();

            file.GetAudioFiles(dropedFiles, listViewAudioFiles, this.audioFilesList, this.audioFilesPathDictionary);

            if (this.firstDragAndDrop)
            {
                if (listViewAudioFiles.Items.Count > 0)
                {
                    string path = audioFilesList[guiMain.CurrentIndex];
                    this.setFormAttributes(path);
                    guiMain.FilePathLabel = path;
                }
            }

            guiMain.ManageFormComponents(true);

            this.firstDragAndDrop = false;
        }

        public void RefreshListView(ListView listViewAudioFiles)
        {
            listViewAudioFiles.Items.Clear();
            foreach (string path in audioFilesList)
            {
                listViewAudioFiles.Items.Add(System.IO.Path.GetFileName(path));
            }

            this.setFormAttributes(this.audioFilesList[0]);
            guiMain.ManageFormComponents(true);
            guiMain.ItemsCountLabel = listViewAudioFiles.Items.Count.ToString();
        }

        public void SaveToFile(bool applyToAll, bool autoNext, int format, ListView listViewAudioFiles)
        {
            IFormComboBoxContainer editedTags;

            int i = guiMain.CurrentIndex;
            bool firstSave = true;
            IAudioFile file = ObjectFactory.GetAudioFileManager();
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

                        editedTags = guiMain.GetComboBoxesContent();

                        if (userDecision != "Continue")
                            userDecision = this.FormChecker(editedTags);

                        if (listLength != 0 && (userDecision == null || userDecision == "Continue"))
                        {
                            originalPath = filePath;

                            file.Write(filePath, editedTags);
                            filePath = file.Rename(filePath, editedTags, format);
                            listViewAudioFiles.Items[i].Text = System.IO.Path.GetFileName(filePath);
                            audioFilesList[i] = filePath;
                            this.UpdateAudioFilesDictionary(audioFilesPathDictionary, originalPath, audioFilesList[i]);

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
                        this.LoadFileTags(0);
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

        private void UpdateAudioFilesDictionary(Iterate audioFilesPathDictionary, string oldPath, string newPath)
        {
            audioFilesPathDictionary.Remove(oldPath);

            int newPathDictionaryIndex = newPath.GetHashCode();

            audioFilesPathDictionary.Add(newPath);
        }

        private string DatabaseChooserGetPath()
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

        public bool CheckDBFileAndSave(bool resetPath = false)
        {
            if (!System.IO.File.Exists(Properties.Settings.Default.DatabasePath) || resetPath)
            {
                string path = this.DatabaseChooserGetPath();
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

        private void LoadTagArt(PictureBox tagArtBox, string filePath)
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

        public void LoadFileTags(int index)
        {
            this.setFormAttributes(this.audioFilesList[index]);
        }

        private void setFormAttributes(string filePath)
        {
            IAudioFile file = null;

            if (file == null)
                file = new AudioFile();

            this.guiMain.SetComboBoxesContent(file.Read(filePath));

            this.LoadTagArt(guiMain.TagArt, filePath);
            guiMain.FilePathLabel = filePath;
        }

        public string FormChecker(IFormComboBoxContainer audioFileTags)
        {
            IVerify iVerifyForm = ObjectFactory.GetVerifier();
            string userDecision = null;

            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.Title);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.Artist);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.ContributingArtists);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.Album);
            if (userDecision == null)
                userDecision = iVerifyForm.nullTagChecker(audioFileTags.Genre);

            return userDecision;
        }

        IQuery tagDB;
        IDatabaseSuggest suggestions;
        IDatabaseAdd add;
        string userDecision = null;
        public void ManageSuggestions()
        {
            this.CheckDBFileAndSave();

            if (tagDB == null)
                tagDB = ObjectFactory.GetQuerier(Properties.Settings.Default.DatabasePath);

            if (suggestions == null)
                suggestions = ObjectFactory.GetDatabaseSuggestor(tagDB);
            IFormComboBoxContainer currentComboBoxContent = guiMain.GetComboBoxesContent();

            List<IFormComboBoxContainer> suggestionResults = suggestions.GetSuggestions(currentComboBoxContent);

            if (suggestionResults.Count != 0)
                guiMain.SetComboBoxesContent(suggestionResults);
        }
        public bool ManageAdditionsToDB()
        {
            IFormComboBoxContainer tags = guiMain.GetComboBoxesContent();

            if (tagDB == null)
                tagDB = ObjectFactory.GetQuerier(Properties.Settings.Default.DatabasePath);

            if (add == null)
                add = ObjectFactory.GetDatabaseAdd(tagDB);

            userDecision = this.FormChecker(tags);
            if (userDecision == null || userDecision == "Continue")
            {
                add.AddToDatabase(guiMain.GetComboBoxesContent());
                guiMain.CurrentIndex += 1;
                this.setFormAttributes(this.audioFilesList[guiMain.CurrentIndex]);
                return true;
            }
            else if (userDecision == "Skip")
            {
                guiMain.CurrentIndex += 1;
                this.setFormAttributes(this.audioFilesList[guiMain.CurrentIndex]);
                return true;
            }
            else
                return false;
        }

        public void SearchAndReplace(string find, string replace, bool applyToAll)
        {
            IAudioFile file = null;

            if (file == null)
                file = ObjectFactory.GetAudioFileManager();

            if (applyToAll)
                file.SearchAndReplace(this.audioFilesList, find, replace);
            else
                file.SearchAndReplace(this.audioFilesList[guiMain.CurrentIndex], find, replace);

            this.LoadFileTags(guiMain.CurrentIndex);
        }

        #region Variables

        private List<string> audioFilesList = new List<string>();
        public List<string> AudioFilesList
        {
            get { return audioFilesList; }
            set { audioFilesList = value; }
        }

        private Iterate audioFilesPathDictionary = ObjectFactory.GetIterator();
        public Iterate AudioFilesPathDictionary
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
