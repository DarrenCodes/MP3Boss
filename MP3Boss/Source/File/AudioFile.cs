using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MP3Boss.Source.Datastructures;
using MP3Boss.Source.Objects;

namespace MP3Boss.Source.File
{
    public class AudioFile : IAudioFile
    {
        private bool FillWithFiles(string file, ListView listViewAudioFiles, List<string> audioFilesList, Iterate audioFilesDictionary)
        {
            if (System.IO.File.Exists(file))
            {
                if (!audioFilesDictionary.Contains(file))
                {
                    audioFilesDictionary.Add(file);
                    audioFilesList.Add(file);
                    listViewAudioFiles.Items.Add(System.IO.Path.GetFileName(file));
                }
                return true;
            }
            else return false;
        }

        //Gets all Audio files in selected directory(s)
        public bool GetAudioFiles(string[] dropedFiles, ListView listViewAudioFiles, List<string> audioFilesList, Iterate audioFilesDictionary)
        {
            bool newValuesAdded = false;

            foreach (string file in dropedFiles.Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
            {
                newValuesAdded = FillWithFiles(file, listViewAudioFiles, audioFilesList, audioFilesDictionary);
            }

            List<string> folders = new List<string>();
            foreach (string folder in dropedFiles)
            {
                if (System.IO.Directory.Exists(folder))
                    folders.Add(folder);
            }

            //Message prompt asking the user if subdirectories should be searched for audio files and included as well
            DialogResult subDirectorySelection = default(DialogResult);
            if (folders.Count > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButtons.YesNo);

            //This section of code will search and extract all audio files from the given directories
            foreach (string folder in folders)
            {
                if (subDirectorySelection == DialogResult.Yes)
                {
                    foreach (string file in Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
                    {
                        newValuesAdded = FillWithFiles(file, listViewAudioFiles, audioFilesList, audioFilesDictionary);
                    }
                }
                else if (subDirectorySelection == DialogResult.No)
                {
                    foreach (string file in Directory.GetFiles(folder, "*.*").Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
                    {
                        newValuesAdded = FillWithFiles(file, listViewAudioFiles, audioFilesList, audioFilesDictionary);
                    }
                }
            }

            return newValuesAdded;
        }

        public IFormComboBoxContainer Read(string filePath)
        {
            return ObjectFactory.GetNewComboBoxContainer(ObjectFactory.GetTagLibrary(filePath));
        }

        public bool Write(string filePath, IFormComboBoxContainer tagUpdates)
        {
            IFileTagTools file = ObjectFactory.GetTagLibrary(filePath);
            file.Title = tagUpdates.Title;
            file.ArtistName = tagUpdates.Artist;
            file.ContributingArtistName = tagUpdates.ContributingArtists;
            file.AlbumName = tagUpdates.Album;
            file.SongYear = tagUpdates.Year;
            file.TrackNo = tagUpdates.TrackNo;
            file.Genre = tagUpdates.Genre;
            file.Save();

            return true;
        }

        public string Rename(string filePath, IFormComboBoxContainer tags, int format)
        {
            string formmatedFilename = this.GenerateFormattedName(filePath, tags, format);

            string newFilePath = System.IO.Path.GetDirectoryName(filePath) + "\\" + formmatedFilename;

            if (System.IO.File.Exists(filePath))
                System.IO.File.Move(filePath, newFilePath);
            else
                MessageBox.Show("The file at:" + filePath + " was not found.", "Error!");

            return newFilePath;
        }

        private string GenerateFormattedName(string filePath, IFormComboBoxContainer tags, int format)
        {
            string title = tags.Title;
            uint track = tags.TrackNo;
            string artist = tags.Artist;

            string fileDirectoryPath = System.IO.Path.GetDirectoryName(filePath);

            string validFilenameFormat = @"^[\w\-.\(\)\[\]\s&']+$";
            string invalidFilenameChars = @"[^\w\-.\(\)\s&']+";

            string formattedFileName = "";

            //Generate formatted filename
            switch (format)
            {
                case 1: //#. Title - Artist     format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            title + " - " + artist + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 2: //#. Artist - Title     format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            artist + " - " + title + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 3: //Artist - Title    format
                    {
                        formattedFileName = artist + " - " + title +
                            System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 4: //#. Title      format
                    {
                        formattedFileName =  (track < 10 ? "0" : "") + track + ". " +
                            title + System.IO.Path.GetExtension(filePath);

                        break;
                    }
                case 5: //Title - Artist      format
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
                    DialogResult result = default(DialogResult);

                    result = MessageBox.Show("Invalid charachters in potential filename: " + formattedFileName +
                        "\nRemove invalid characters?",
                        "Error!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
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

        public void SearchAndReplace(string filePath, string find, string replace)
        {
            IFormComboBoxContainer tags = this.Read(filePath);

            tags.Title = tags.Title.Replace(find, replace);
            tags.Artist = tags.Artist.Replace(find, replace);

            Iterate tempContributingArtist = ObjectFactory.GetIterator(tags.ContributingArtists);
            foreach (string artist in tags.ContributingArtists)
            {
                string currentString = artist;
                if (currentString.Contains(find))
                {
                    tempContributingArtist.Remove(currentString);
                    tempContributingArtist.Add(currentString.Replace(find, replace));
                }
            }
            tags.ContributingArtists = tempContributingArtist;

            tags.Album = tags.Album.Replace(find, replace);
            tags.Year = tags.Year;
            tags.TrackNo = tags.TrackNo;
            
            Iterate tempGenre = ObjectFactory.GetIterator(tags.Genre);
            foreach (string genre in tags.Genre)
            {
                string currentString = genre;
                if (currentString.Contains(find))
                {
                    tempGenre.Remove(currentString);
                    tempGenre.Add(currentString.Replace(find, replace));
                }
            }
            tags.Genre = tempGenre;

            this.Write(filePath, tags);
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
