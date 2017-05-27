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
    public class AudioFile
    {
        //Gets all Audio files in selected directory(s)
        public static List<string> GetAudioFiles(string[] dropedFiles)
        {
            List<string> fullPathAudioFilesList = new List<string>();
            List<string> unprocessedDroppedItems = dropedFiles.ToList();

            Action<string[]> GetFiles = (filesList) =>
            {
                foreach (string file in filesList.Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
                {
                    if (System.IO.File.Exists(file) && !fullPathAudioFilesList.Contains(file))
                    {
                        fullPathAudioFilesList.Add(file);
                        unprocessedDroppedItems.Remove(file);
                    }
                };
            };

            GetFiles(dropedFiles);

            List<string> folders = new List<string>();
            foreach (string folder in unprocessedDroppedItems)
            {
                if (Directory.Exists(folder))
                    folders.Add(folder);
            }

            //Message prompt asking the user if subdirectories should be searched for audio files and included as well
            MessageBoxResult subDirectorySelection = default(MessageBoxResult);
            if (folders.Count > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButton.YesNo);

            foreach (string folder in folders)
            {
                if (subDirectorySelection == MessageBoxResult.Yes)
                    GetFiles(Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories));
                else if (subDirectorySelection == MessageBoxResult.No)
                    GetFiles(Directory.GetFiles(folder, "*.*"));
            }

            return fullPathAudioFilesList;
        }

        public static void Read(string filePath, IWindowProperties formPropertiesObject)
        {
            IFileTagTools file = ObjectFactory.GetTagLibrary(filePath);
            Assign.AssignTo(formPropertiesObject, file, formPropertiesObject);
            formPropertiesObject.TagArt = file.TagArt;
        }

        public static void Write(string filePath, IWindowProperties formPropertiesObject)
        {
            IFileTagTools file = ObjectFactory.GetTagLibrary(filePath);
            Assign.AssignTo(file, formPropertiesObject);
            file.Save();   
        }

        public static string Rename(string filePath, IWindowProperties formPropertiesObject)
        {
            string formmatedFilename = GenerateFormattedName(filePath, formPropertiesObject);

            string newFilePath = Path.GetDirectoryName(filePath) + "\\" + formmatedFilename;

            if (System.IO.File.Exists(filePath))
                System.IO.File.Move(filePath, newFilePath);
            else
                MessageBox.Show("The file at:" + filePath + " was not found.", "Error!");

            return newFilePath;
        }

        private static string GenerateFormattedName(string filePath, IWindowProperties formPropertiesObject)
        {
            Func<ObservableCollection<string>, string> nullCheck = (collection) =>
            {
                if (!(collection == null))
                    return collection[0];
                else
                    return "";
            };

            string title = nullCheck(formPropertiesObject.Title);
            uint track = uint.Parse(formPropertiesObject.TrackNo[0]);
            string artist = formPropertiesObject.Artist[0];

            string fileDirectoryPath = System.IO.Path.GetDirectoryName(filePath);

            string invalidFilenameChars = @"[\\/:?*""<>|]+";

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
                if (!Regex.IsMatch(formattedFileName, invalidFilenameChars))
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

        public static void SearchAndReplace(string filePath, string find, string replacement)
        {
            IFileTagTools tags = ObjectFactory.GetTagLibrary(filePath);
            
            tags.Title = tags.Title.Replace(find, replacement);
            tags.Artist = tags.Artist.Replace(find, replacement);
            tags.ContributingArtists = tags.ContributingArtists.Replace(find, replacement);
            tags.Album = tags.Album.Replace(find, replacement);
            tags.Genre = tags.Genre.Replace(find, replacement);

            tags.Save();
        }
        public static void SearchAndReplace(List<string> audioFilesList, string find, string replace)
        {
            if (audioFilesList != null && audioFilesList.Count != 0)
            {
                foreach (string path in audioFilesList)
                    SearchAndReplace(path, find, replace);
            }
            else
                MessageBox.Show("No files found.", "Error!");
        }
    }
}
