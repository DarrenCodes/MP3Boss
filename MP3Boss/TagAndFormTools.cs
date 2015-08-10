using System.Linq;
using System.IO;
using System.Windows.Forms;
using System;

namespace MP3Boss
{
    class TagAndFormTools
    {
        internal void populateListView(FormMP3Boss obj)
        {
            obj.listViewMP3s.Items.Clear();

            obj.files = Directory.GetFiles(obj.fBDialogLoadMP3s.SelectedPath, "*.mp3", SearchOption.AllDirectories); //Loads mp3 files from selected path

            if (obj.files != null)
            {
                //Adds list of files to List View element in GUI
                foreach (string file in obj.files)
                {
                    obj.listViewMP3s.Items.Add(file.Substring(file.LastIndexOf('\\') + 1), file.LastIndexOf('.'));
                }
            }
        }

        //Set the attributes of the song according to the selected item in its respective Main Form textboxes
        internal void setFormAttributes(string path, FormMP3Boss obj)
        {
            TagLib.File file = TagLib.File.Create(path);

            clearFormAttributes(obj);

            //Instantiate object with address of selected MP3 file
            if (obj.cBoxTitle.Checked != true)
                obj.tBoxTitle.Text = file.Tag.Title;
            if (obj.cBoxAlbumArtist.Checked != true)
                obj.tBoxAlbumArtist.Text = file.Tag.FirstAlbumArtist;
            //Loop for finding & displaying all contributing artists from MP3 file (array)
            if (obj.cBoxContArtists.Checked != true)
            {
                for (int i = 0; i < file.Tag.Performers.Length; i++)
                {
                    if (i == (file.Tag.Performers.Length - 1))
                    {
                        obj.tBoxContArtists.Text += file.Tag.Performers[i];
                    }
                    else
                        obj.tBoxContArtists.Text += file.Tag.Performers[i] + ";";
                }
            }
            if (obj.cBoxAlbum.Checked != true)
                obj.tBoxAlbum.Text = file.Tag.Album;
            if (obj.cBoxYear.Checked != true)
                obj.tBoxYear.Text = file.Tag.Year.ToString();
            if (obj.cBoxTrackNo.Checked != true)
                obj.tBoxTrackNo.Text = file.Tag.Track.ToString();
            if (obj.cBoxGenre.Checked != true)
            {
                for (int i = 0; i < file.Tag.Genres.Length; i++)
                {
                    if (i == (file.Tag.Genres.Length - 1))
                    {
                        obj.tBoxGenre.Text += file.Tag.Genres[i];
                    }
                    else
                        obj.tBoxGenre.Text += file.Tag.Genres[i] + ";";
                }
            }
        }

        internal void renameFiles(string originalPath, string newFileName, FormMP3Boss obj)
        {
            try
            {
                System.IO.File.Move(originalPath, newFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Important Message");
            }
        }

        //Clear all text from the Main Form textboxs
        internal void clearFormAttributes(FormMP3Boss obj)
        {
            if (obj.cBoxTitle.Checked != true)
                obj.tBoxTitle.Clear();
            if (obj.cBoxAlbumArtist.Checked != true)
                obj.tBoxAlbumArtist.Clear();
            if (obj.cBoxContArtists.Checked != true)
                obj.tBoxContArtists.Clear();
            if (obj.cBoxAlbum.Checked != true)
                obj.tBoxAlbum.Clear();
            if (obj.cBoxYear.Checked != true)
                obj.tBoxYear.Clear();
            if (obj.cBoxTrackNo.Checked != true)
                obj.tBoxTrackNo.Clear();
            if (obj.cBoxGenre.Checked != true)
                obj.tBoxGenre.Clear();
        }

        internal void saveChangesToFile(string path, FormMP3Boss obj)
        {
            TagLib.File file = TagLib.File.Create(path);

            if (obj.tBoxTitle.Text != file.Tag.Title)
                file.Tag.Title = obj.tBoxTitle.Text;

            if (obj.tBoxAlbumArtist.Text != file.Tag.FirstAlbumArtist)
            {
                file.Tag.AlbumArtists = null;
                file.Tag.AlbumArtists = new[] { obj.tBoxAlbumArtist.Text };
            }

            string[] contArtistArr = obj.tBoxContArtists.Text.Split(';'); //Split user entered string into array
            bool contEqual = Enumerable.SequenceEqual(file.Tag.Performers, contArtistArr); //Check if user changed field
            //Copy user's changes to tag
            if (contEqual == false)
            {
                file.Tag.Performers = null; //Clear tag (sorts out bug)
                file.Tag.Performers = contArtistArr;
            }

            if (obj.tBoxAlbum.Text != file.Tag.Album)
                file.Tag.Album = obj.tBoxAlbum.Text;

            if (obj.tBoxYear.Text != file.Tag.Year.ToString())
                file.Tag.Year = uint.Parse(obj.tBoxYear.Text);

            if (obj.tBoxTrackNo.Text != file.Tag.Track.ToString())
                file.Tag.Track = uint.Parse(obj.tBoxTrackNo.Text);

            string[] genre = obj.tBoxGenre.Text.Split(';'); //Split user entered string into array
            bool genreEqual = Enumerable.SequenceEqual(file.Tag.Genres, genre); //Check if user changed field

            //Copy user's changes to tag
            if (genreEqual == false)
            {
                file.Tag.Genres = null; //Clear tag (sorts out bug)
                file.Tag.Genres = genre;
            }

            file.Save();


            switch (obj.comboBoxFormat.SelectedIndex)
            {
                case 1: //#. Title - Artist     format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Track + ". " +
                            file.Tag.Title + " - " +
                            file.Tag.FirstAlbumArtist + ".mp3";

                        renameFiles(path, newFileName, obj);

                        break;
                    }
                case 2: //#. Artist - Title     format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Track + ". " +
                            file.Tag.FirstAlbumArtist + " - " +
                            file.Tag.Title + ".mp3";

                        renameFiles(path, newFileName, obj);

                        break;
                    }
                case 3: //Artist - Title    format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.FirstAlbumArtist + " - " +
                            file.Tag.Title + ".mp3";

                        renameFiles(path, newFileName, obj);

                        break;
                    }
                case 4: //#. Title      format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Track + ". " +
                            file.Tag.Title + ".mp3";

                        renameFiles(path, newFileName, obj);

                        break;
                    }
                case 5: //Title - Artist      format
                    {
                        string newFileName = path.Substring(0, path.LastIndexOf('\\') + 1) +
                            file.Tag.Title + " - " + 
                            file.Tag.FirstAlbumArtist + ".mp3";

                        renameFiles(path, newFileName, obj);

                        break;
                    }
                default:
                    break;
            }
        }
    }
}
