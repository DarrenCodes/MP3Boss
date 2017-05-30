using Microsoft.Win32;
using MP3Boss.Source.Database;
using MP3Boss.Source.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace MP3Boss.Source.GUI.Backend
{
    public class FormManager
    {
        //private IWindowProperties formPropertiesObject;

        //public FormManager(IWindowProperties formPropertiesObject)
        //{
        //    this.formPropertiesObject = formPropertiesObject;
        //    Reset();
        //}

        //public void Reset()
        //{
        //    formPropertiesObject.FullPathAudioFilesList.Clear();
        //    formPropertiesObject.ListViewAudioFilesList.Clear();
        //    FirstDragAndDrop = true;
        //}

        //public void FillFileList(string[] dropedFiles)
        //{
        //    IAudioFile file = ObjectFactory.GetAudioFileManager();

        //    file.GetAudioFiles(dropedFiles, formPropertiesObject.ListViewAudioFilesList, formPropertiesObject.FullPathAudioFilesList);

        //    if (FirstDragAndDrop)
        //    {
        //        if (formPropertiesObject.FullPathAudioFilesList.Count > 0)
        //        {
        //            string path = formPropertiesObject.FullPathAudioFilesList[formPropertiesObject.CurrentIndex];
        //            SetFormAttributes(path);
        //            formPropertiesObject.FilePathLabel = path;
        //        }
        //    }

        //    FirstDragAndDrop = false;
        //}

        //public void RefreshListView()
        //{
        //    for (int i = 0; i < formPropertiesObject.FullPathAudioFilesList.Count; i++)
        //    {
        //        if (!System.IO.File.Exists(formPropertiesObject.FullPathAudioFilesList[i]))
        //            formPropertiesObject.FullPathAudioFilesList.RemoveAt(i);
        //    }

        //    SetFormAttributes(0);
        //}

        //private void UpdateAudioFilesDictionary(Dictionary<int, string> audioFilesPathDictionary, string oldPath, string newPath)
        //{
        //    audioFilesPathDictionary.Remove(oldPath.GetHashCode());

        //    int newPathDictionaryIndex = newPath.GetHashCode();

        //    audioFilesPathDictionary.Add(newPath.GetHashCode(), newPath);
        //}

        //private string DatabaseChooserGetPath()
        //{
        //    string path = "";
        //    OpenFileDialog findFile = new OpenFileDialog();
        //    findFile.Filter = "SQLite Files (.sqlite)|*.sqlite";

        //    bool result = findFile.ShowDialog().Value;

        //    if (result)
        //        path = findFile.FileName;

        //    return path;
        //}

        //public bool CheckDBFileAndSave(bool resetPath = false)
        //{
        //    if (!System.IO.File.Exists(Properties.Settings.Default.DatabasePath) || resetPath)
        //    {
        //        string path = this.DatabaseChooserGetPath();
        //        if (System.IO.File.Exists(path))
        //        {
        //            Properties.Settings.Default.DatabasePath = path;
        //            Properties.Settings.Default.Save();
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //        return true;
        //}

        //private void ClearBindingObjectCollections()
        //{
        //    Action<ObservableCollection<string>> clear = (collection) => collection.Clear();
        //    Action<ObservableCollection<string>, bool> clearIfNotLocked = (collection, isLockedStatus) =>
        //    {
        //        if (!isLockedStatus)
        //            clear(collection);
        //    };

        //    clearIfNotLocked(formPropertiesObject.Title, formPropertiesObject.CheckBoxTitle);
        //    clearIfNotLocked(formPropertiesObject.Artist, formPropertiesObject.CheckBoxArtist);
        //    clearIfNotLocked(formPropertiesObject.ContributingArtists, formPropertiesObject.CheckBoxContributingArtists);
        //    clearIfNotLocked(formPropertiesObject.Album, formPropertiesObject.CheckBoxAlbum);
        //    clearIfNotLocked(formPropertiesObject.Year, formPropertiesObject.CheckBoxYear);
        //    clearIfNotLocked(formPropertiesObject.TrackNo, formPropertiesObject.CheckBoxTrackNo);
        //    clearIfNotLocked(formPropertiesObject.Genre, formPropertiesObject.CheckBoxGenre);
        //}

        //IAudioFile file = null;
        //public void SetFormAttributes(int index)
        //{
        //    if (formPropertiesObject.FullPathAudioFilesList.Count > index)
        //        SetFormAttributes(formPropertiesObject.FullPathAudioFilesList[index]);
        //}
        //private void SetFormAttributes(string filePath)
        //{
        //    if (file == null)
        //        file = new FileDirectoryManipulation();

        //    ClearBindingObjectCollections();
        //    file.Read(filePath, formPropertiesObject);
        //    formPropertiesObject.FilePathLabel = filePath;

        //}

        //public string FormChecker(IWindowProperties audioFileTags)
        //{
        //    IVerify iVerifyForm = ObjectFactory.GetVerifier();
        //    string userDecision = null;

        //    Action<string> checkForNullTags = (tag) =>
        //    {
        //        if (userDecision == null)
        //            userDecision = iVerifyForm.nullTagChecker(tag);
        //    };

        //    checkForNullTags(audioFileTags.Title[0]);
        //    checkForNullTags(audioFileTags.Artist[0]);
        //    checkForNullTags(audioFileTags.ContributingArtists[0]);
        //    checkForNullTags(audioFileTags.Album[0]);
        //    checkForNullTags(audioFileTags.Genre[0]);

        //    return userDecision;
        //}

        //IDatabaseSuggest suggestions;
        //public void ManageSuggestions()
        //{
        //    CheckDBFileAndSave();

        //    if (suggestions == null)
        //        suggestions = ObjectFactory.GetDatabaseSuggestor(Properties.Settings.Default.DatabasePath);

        //    suggestions.GetSuggestions(formPropertiesObject);
        //}

        //IDatabaseAdd add;
        //string userDecision = null;
        //public bool ManageAdditionsToDB()
        //{
        //    this.CheckDBFileAndSave();

        //    if (add == null)
        //        add = ObjectFactory.GetDatabaseAdd(Properties.Settings.Default.DatabasePath);

        //    userDecision = FormChecker(formPropertiesObject);
        //    if (userDecision == null || userDecision == "Continue")
        //    {
        //        add.AddToDatabase(formPropertiesObject);
        //        formPropertiesObject.CurrentIndex += 1;
        //        if (formPropertiesObject.CurrentIndex < formPropertiesObject.FullPathAudioFilesList.Count)
        //            SetFormAttributes(formPropertiesObject.FullPathAudioFilesList[formPropertiesObject.CurrentIndex]);
        //        else
        //            SetFormAttributes(formPropertiesObject.FullPathAudioFilesList[0]);

        //        return true;
        //    }
        //    else if (userDecision == "Skip")
        //    {
        //        formPropertiesObject.CurrentIndex += 1;
        //        SetFormAttributes(formPropertiesObject.FullPathAudioFilesList[formPropertiesObject.CurrentIndex]);
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public void SearchAndReplace(string find, string replace, bool applyToAll)
        //{
        //    IAudioFile file = null;

        //    if (file == null)
        //        file = ObjectFactory.GetAudioFileManager();

        //    if (applyToAll)
        //        file.SearchAndReplace(formPropertiesObject.FullPathAudioFilesList, find, replace);
        //    else
        //        file.SearchAndReplace(formPropertiesObject.FullPathAudioFilesList[formPropertiesObject.CurrentIndex], find, replace);

        //    SetFormAttributes(formPropertiesObject.CurrentIndex);
        //}

        //#region Variables

        //private bool FirstDragAndDrop { get; set; }

        //#endregion
    }
}
