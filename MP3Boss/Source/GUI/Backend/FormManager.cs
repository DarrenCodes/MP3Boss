using System;
using System.Collections.Generic;
using System.IO;
using MP3Boss.Source.File;
using MP3Boss.Source.Objects;
using MP3Boss.Source.DataStructures;
using MP3Boss.Source.Validation;
using MP3Boss.Source.Database;
using System.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace MP3Boss.Source.GUI.Backend
{
    public class FormManager : IFormManager
    {
        private IWindowProperties formPropertiesObject;

        public FormManager(IWindowProperties formPropertiesObject)
        {
            this.formPropertiesObject = formPropertiesObject;
            Reset();
        }

        public void Reset()
        {
            AudioFilesList = new List<string>();
            AudioFilesPathDictionary = new Dictionary<int, string>();
            FirstDragAndDrop = true;
        }

        public void FillFileList(string[] dropedFiles)
        {
            IAudioFile file = ObjectFactory.GetAudioFileManager();

            file.GetAudioFiles(dropedFiles, AudioFilesList, formPropertiesObject.ListViewAudioFiles, AudioFilesPathDictionary);

            if (FirstDragAndDrop)
            {
                if (AudioFilesList.Count > 0)
                {
                    string path = AudioFilesList[formPropertiesObject.CurrentIndex];
                    SetFormAttributes(path);
                    formPropertiesObject.FilePathLabel = path;
                }
            }

            FirstDragAndDrop = false;
        }

        public void RefreshListView()
        {
            for (int i = 0; i < AudioFilesList.Count; i++)
            {
                if (!System.IO.File.Exists(AudioFilesList[i]))
                    AudioFilesList.RemoveAt(i);
            }

            SetFormAttributes(0);
        }

        public void SaveToFile(bool applyToAll, bool autoNext)
        {
            int i = formPropertiesObject.CurrentIndex;
            bool firstSave = true;
            IAudioFile file = ObjectFactory.GetAudioFileManager();
            int loopEnd = 0;
            int originalIndex = 0;
            string originalPath = "";

            int listLength = formPropertiesObject.ListViewAudioFiles.Count;
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
                        filePath = AudioFilesList[i];

                        if (firstSave == false)
                            this.SetFormAttributes(filePath);

                        if (userDecision != "Continue")
                            userDecision = this.FormChecker(formPropertiesObject);

                        bool isAllowedToSave = (userDecision == null || userDecision == "Continue");

                        if (listLength != 0 && isAllowedToSave)
                        {
                            originalPath = filePath;

                            file.Write(filePath, formPropertiesObject);
                            filePath = file.Rename(filePath, formPropertiesObject);
                            formPropertiesObject.ListViewAudioFiles[i] = System.IO.Path.GetFileName(filePath);
                            AudioFilesList[i] = filePath;
                            this.UpdateAudioFilesDictionary(AudioFilesPathDictionary, originalPath, AudioFilesList[i]);

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

                        formPropertiesObject.StatusLabel = "Done.";
                    }

                    if (i >= AudioFilesList.Count)
                    {
                        formPropertiesObject.CurrentIndex = 0;
                        this.SetFormAttributes(0);
                    }
                    #endregion

                    #region Go to next file
                    if ((autoNext == true || userDecision == "Skip") && i < listLength)
                    {
                        this.SetFormAttributes(this.AudioFilesList[i]);
                        ++formPropertiesObject.CurrentIndex;
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

        private void UpdateAudioFilesDictionary(Dictionary<int, string> audioFilesPathDictionary, string oldPath, string newPath)
        {
            audioFilesPathDictionary.Remove(oldPath.GetHashCode());

            int newPathDictionaryIndex = newPath.GetHashCode();

            audioFilesPathDictionary.Add(newPath.GetHashCode(), newPath);
        }

        private string DatabaseChooserGetPath()
        {
            string path = "";
            OpenFileDialog findFile = new OpenFileDialog();
            findFile.Filter = "SQLite Files (.sqlite)|*.sqlite";

            bool result = findFile.ShowDialog().Value;

            if (result)
                path = findFile.FileName;

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

        private void ClearBindingObjectCollections()
        {
            Action<ObservableCollection<string>> clear = (collection) => collection.Clear();
            Action<ObservableCollection<string>, bool> clearIfNotLocked = (collection, isLockedStatus) =>
            {
                if (!isLockedStatus)
                    clear(collection);
            };

            clearIfNotLocked(formPropertiesObject.Title, formPropertiesObject.CheckBoxTitle);
            clearIfNotLocked(formPropertiesObject.Artist, formPropertiesObject.CheckBoxArtist);
            clearIfNotLocked(formPropertiesObject.ContributingArtists, formPropertiesObject.CheckBoxContributingArtists);
            clearIfNotLocked(formPropertiesObject.Album, formPropertiesObject.CheckBoxAlbum);
            clearIfNotLocked(formPropertiesObject.Year, formPropertiesObject.CheckBoxYear);
            clearIfNotLocked(formPropertiesObject.TrackNo, formPropertiesObject.CheckBoxTrackNo);
            clearIfNotLocked(formPropertiesObject.Genre, formPropertiesObject.CheckBoxGenre);
        }

        IAudioFile file = null;
        public void SetFormAttributes(int index)
        {
            SetFormAttributes(AudioFilesList[index]);
        }
        private void SetFormAttributes(string filePath)
        {
            if (file == null)
                file = new AudioFile();

            ClearBindingObjectCollections();
            file.Read(filePath, formPropertiesObject);
            formPropertiesObject.FilePathLabel = filePath;

        }

        public string FormChecker(IWindowProperties audioFileTags)
        {
            IVerify iVerifyForm = ObjectFactory.GetVerifier();
            string userDecision = null;

            Action<string> checkForNullTags = (tag) =>
            {
                if (userDecision == null)
                    userDecision = iVerifyForm.nullTagChecker(tag);
            };

            checkForNullTags(audioFileTags.Title[0]);
            checkForNullTags(audioFileTags.Artist[0]);
            checkForNullTags(audioFileTags.ContributingArtists[0]);
            checkForNullTags(audioFileTags.Album[0]);
            checkForNullTags(audioFileTags.Genre[0]);

            return userDecision;
        }

        IDatabaseSuggest suggestions;
        public void ManageSuggestions()
        {
            CheckDBFileAndSave();

            if (suggestions == null)
                suggestions = ObjectFactory.GetDatabaseSuggestor(Properties.Settings.Default.DatabasePath);

            suggestions.GetSuggestions(formPropertiesObject);
        }

        IDatabaseAdd add;
        string userDecision = null;
        public bool ManageAdditionsToDB()
        {
            this.CheckDBFileAndSave();

            if (add == null)
                add = ObjectFactory.GetDatabaseAdd(Properties.Settings.Default.DatabasePath);

            userDecision = FormChecker(formPropertiesObject);
            if (userDecision == null || userDecision == "Continue")
            {
                add.AddToDatabase(formPropertiesObject);
                formPropertiesObject.CurrentIndex += 1;
                if (formPropertiesObject.CurrentIndex < AudioFilesList.Count)
                    SetFormAttributes(AudioFilesList[formPropertiesObject.CurrentIndex]);
                else
                    SetFormAttributes(AudioFilesList[0]);

                return true;
            }
            else if (userDecision == "Skip")
            {
                formPropertiesObject.CurrentIndex += 1;
                SetFormAttributes(AudioFilesList[formPropertiesObject.CurrentIndex]);
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
                file.SearchAndReplace(AudioFilesList, find, replace);
            else
                file.SearchAndReplace(AudioFilesList[formPropertiesObject.CurrentIndex], find, replace);

            SetFormAttributes(formPropertiesObject.CurrentIndex);
        }

        #region Variables

        private List<string> AudioFilesList { get; set; }
        private Dictionary<int, string> AudioFilesPathDictionary { get; set; }
        private bool FirstDragAndDrop { get; set; }

        #endregion
    }
}
