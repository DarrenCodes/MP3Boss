using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MP3Boss.Source.DataStructures;
using MP3Boss.Source.Objects;
using System.Windows;
using System;
using System.Collections.ObjectModel;

namespace MP3Boss.Source.File
{
    public class AudioFile : IAudioFile
    {
        private bool FillWithFiles(string file, List<string> AudioFilesList, ObservableCollection<string> ListViewCollection, Dictionary<int, string> AudioFilesDictionary)
        {
            if (System.IO.File.Exists(file) && !AudioFilesDictionary.Values.Contains(file))
            {
                AudioFilesDictionary.Add(file.GetHashCode(), file);
                AudioFilesList.Add(file);
                ListViewCollection.Add(System.IO.Path.GetFileName(file));
                return true;
            }
            else return false;
        }

        //Gets all Audio files in selected directory(s)
        public bool GetAudioFiles(string[] dropedFiles, List<string> AudioFilesList, ObservableCollection<string> ListViewCollection, Dictionary<int, string> AudioFilesDictionary)
        {
            bool newValuesAdded = false;

            Action<string[]> getFiles = (filesList) =>
            {
                foreach (string file in filesList.Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
                {
                    newValuesAdded = FillWithFiles(file, AudioFilesList, ListViewCollection, AudioFilesDictionary);
                };
            };

            getFiles(dropedFiles);

            List<string> folders = new List<string>();
            foreach (string folder in dropedFiles)
            {
                if (System.IO.Directory.Exists(folder))
                    folders.Add(folder);
            }

            //Message prompt asking the user if subdirectories should be searched for audio files and included as well
            MessageBoxResult subDirectorySelection = default(MessageBoxResult);
            if (folders.Count > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButton.YesNo);

            foreach (string folder in folders)
            {
                if (subDirectorySelection == MessageBoxResult.Yes)
                    getFiles(Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories));
                else if (subDirectorySelection == MessageBoxResult.No)
                    getFiles(Directory.GetFiles(folder, "*.*"));
            }
            
            return newValuesAdded;
        }

        public void Read(string filePath, IWindowProperties formPropertiesObject)
        {
            IFileTagTools file = ObjectFactory.GetTagLibrary(filePath);
            Assign.AssignTo(formPropertiesObject, file, formPropertiesObject);
            formPropertiesObject.TagArt = file.TagArt;
        }

        public bool Write(string filePath, IWindowProperties formPropertiesObject)
        {
            IFileTagTools file = ObjectFactory.GetTagLibrary(filePath);
            Assign.AssignTo(file, formPropertiesObject);
            file.Save();

            return true;
        }

        public string Rename(string filePath, IWindowProperties formPropertiesObject)
        {
            string formmatedFilename = this.GenerateFormattedName(filePath, formPropertiesObject);

            string newFilePath = System.IO.Path.GetDirectoryName(filePath) + "\\" + formmatedFilename;

            if (System.IO.File.Exists(filePath))
                System.IO.File.Move(filePath, newFilePath);
            else
                MessageBox.Show("The file at:" + filePath + " was not found.", "Error!");

            return newFilePath;
        }

        private string GenerateFormattedName(string filePath, IWindowProperties formPropertiesObject)
        {
            string title = formPropertiesObject.Title[0];
            uint track = uint.Parse(formPropertiesObject.TrackNo[0]);
            string artist = formPropertiesObject.Artist[0];

            string fileDirectoryPath = System.IO.Path.GetDirectoryName(filePath);

            string validFilenameFormat = @"^[\w\-.\(\)\[\]\s&']+$";
            string invalidFilenameChars = @"[^\w\-.\(\)\s&']+";

            string formattedFileName = "";

            //Generate formatted filename
            switch (formPropertiesObject.Format)
            {
                case 0: //#. Title - Artist     format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            title + " - " + artist + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 1: //#. Artist - Title     format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            artist + " - " + title + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 2: //Artist - Title    format
                    {
                        formattedFileName = artist + " - " + title +
                            System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 3: //#. Title      format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            title + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 4: //Title - Artist      format
                    {
                        formattedFileName = title + " - " +
                            artist + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                default:
                    break;
            }

            if (formattedFileName != "")
            {
                if (Regex.IsMatch(formattedFileName, validFilenameFormat))
                    return formattedFileName;
                else
                {
                    MessageBoxResult result = default(MessageBoxResult);

                    result = MessageBox.Show("Invalid charachters in potential filename: " + formattedFileName +
                        "\nRemove invalid characters?",
                        "Error!", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        formattedFileName = Regex.Replace(formattedFileName, invalidFilenameChars, "");

                        return formattedFileName;
                    }
                    else
                        return System.IO.Path.GetFileName(filePath);
                }
            }
            else
                return System.IO.Path.GetFileName(filePath);
        }

        public void SearchAndReplace(string filePath, string find, string replacement)
        {
            IFileTagTools tags = ObjectFactory.GetTagLibrary(filePath);

            Func<string, string> replace = (property) => property.Replace(find, replacement);

            tags.Title = replace(tags.Title);
            tags.Artist = replace(tags.Artist);
            tags.ContributingArtists = replace(tags.ContributingArtists);
            tags.TrackNo = replace(tags.TrackNo);
            tags.Year = replace(tags.Year);
            tags.Album = replace(tags.Album);
            tags.Genre = replace(tags.Genre);

            tags.Save();
        }
        public void SearchAndReplace(List<string> audioFilesList, string find, string replace)
        {
            if (audioFilesList != null && audioFilesList.Count != 0)
            {
                foreach (string path in audioFilesList)
                {
                    this.SearchAndReplace(path, find, replace);
                }
            }
            else
                MessageBox.Show("No files found.", "Error!");
        }
    }
}
