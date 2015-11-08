using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using MP3Boss.Source.Interfaces.File;
using MP3Boss.Source.Common.Form.Containers;
using System;
using System.Text.RegularExpressions;

namespace MP3Boss.Source.Classes.File
{
    public class AudioFile : IAudioFile
    {
        //Gets all Audio files in selected directory(s)
        public bool getAudioFiles(string[] dropedFiles, ListView listViewAudioFiles, List<string> audioFilesList, Dictionary<int, string> audioFilesDictionary)
        {
            bool newValuesAdded = false;

            foreach (string file in dropedFiles.Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
            {
                if (System.IO.File.Exists(file))
                {
                    if (!audioFilesDictionary.ContainsKey(file.GetHashCode()))
                    {
                        audioFilesDictionary.Add(file.GetHashCode(), file);
                        audioFilesList.Add(file);
                        listViewAudioFiles.Items.Add(System.IO.Path.GetFileName(file));
                        newValuesAdded = true;
                    }
                }
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
                        if (System.IO.File.Exists(file))
                        {
                            if (!audioFilesDictionary.ContainsKey(file.GetHashCode()))
                            {
                                audioFilesDictionary.Add(file.GetHashCode(), file);
                                audioFilesList.Add(file);
                                listViewAudioFiles.Items.Add(System.IO.Path.GetFileName(file));
                                newValuesAdded = true;
                            }
                        }
                    }
                }
                else if (subDirectorySelection == DialogResult.No)
                {
                    foreach (string file in Directory.GetFiles(folder, "*.*").Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
                    {
                        if (System.IO.File.Exists(file))
                        {
                            if (!audioFilesDictionary.ContainsKey(file.GetHashCode()))
                            {
                                audioFilesDictionary.Add(file.GetHashCode(), file);
                                audioFilesList.Add(file);
                                listViewAudioFiles.Items.Add(System.IO.Path.GetFileName(file));
                                newValuesAdded = true;
                            }
                        }
                    }
                }
            }

            return newValuesAdded;
        }

        public FormContent.ComboBoxesContent read(string filePath)
        {
            TagLib.File audioFile = TagLib.File.Create(filePath);

            FormContent.ComboBoxesContent loadedContent = new FormContent.ComboBoxesContent();

            loadedContent.title = audioFile.Tag.Title;
            loadedContent.artistName = audioFile.Tag.FirstAlbumArtist;
            loadedContent.contributingArtists = audioFile.Tag.Performers.ToList();
            loadedContent.albumName = audioFile.Tag.Album;
            loadedContent.songYear = audioFile.Tag.Year;
            loadedContent.trackNo = audioFile.Tag.Track;
            loadedContent.songGenre = audioFile.Tag.Genres.ToList();

            return loadedContent;
        }

        public bool write(string filePath, FormContent.ComboBoxesContent tagUpdates)
        {
            TagLib.File audioFile = TagLib.File.Create(filePath);

            audioFile.Tag.Title = tagUpdates.title;
            audioFile.Tag.AlbumArtists = new string[1] { tagUpdates.artistName };
            audioFile.Tag.Performers = tagUpdates.contributingArtists.ToArray();
            audioFile.Tag.Album = tagUpdates.albumName;
            audioFile.Tag.Year = tagUpdates.songYear;
            audioFile.Tag.Track = tagUpdates.trackNo;
            audioFile.Tag.Genres = tagUpdates.songGenre.ToArray();

            audioFile.Save();

            return true;
        }

        public string rename(string filePath, FormContent.ComboBoxesContent tags, int format)
        {
            string formmatedFilename = this.generateFormattedName(filePath, tags, format);

            string newFilePath = System.IO.Path.GetDirectoryName(filePath) + "\\" + formmatedFilename;

            if (System.IO.File.Exists(filePath))
                System.IO.File.Move(filePath, newFilePath);
            else
                MessageBox.Show("The file at:" + filePath + " was not found.", "Error!");

            return newFilePath;
        }

        private string generateFormattedName(string filePath, FormContent.ComboBoxesContent tags, int format)
        {
            string title = tags.title;
            uint track = tags.trackNo;
            string artist = tags.artistName;

            string fileDirectoryPath = System.IO.Path.GetDirectoryName(filePath);

            string validFilenameFormat = @"^[\w\-.\(\)\[\]\s&']+$";
            string invalidFilenameChars = @"[^\w\-.\(\)\s&']+";

            string formattedFileName = "";

            //Generate formatted filename
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

        public void searchAndReplace(string filePath, string find, string replace)
        {
            FormContent.ComboBoxesContent tags = this.read(filePath);
            FormContent.ComboBoxesContent updatedTags = new FormContent.ComboBoxesContent();

            updatedTags.title = tags.title.Replace(find, replace);
            updatedTags.artistName = tags.artistName.Replace(find, replace);

            updatedTags.contributingArtists = new List<string>();
            foreach (string artist in tags.contributingArtists)
            {
                updatedTags.contributingArtists.Add(artist.Replace(find, replace));
            }

            updatedTags.albumName = tags.albumName.Replace(find, replace);
            updatedTags.songYear = tags.songYear;
            updatedTags.trackNo = tags.trackNo;

            updatedTags.songGenre = new List<string>();
            foreach (string genre in tags.songGenre)
            {
                updatedTags.songGenre.Add(genre.Replace(find, replace));
            }

            this.write(filePath, updatedTags);
        }
        public void searchAndReplace(List<string> audioFilesList, string find, string replace)
        {
            if (audioFilesList != null && audioFilesList.Count != 0)
            {
                foreach (string path in audioFilesList)
                {
                    this.searchAndReplace(path, find, replace);
                }
            }
            else
                MessageBox.Show("No files found.", "Error!");
        }
    }
}
