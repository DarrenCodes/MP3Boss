using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace MP3Boss
{
    class TagAndFormTools
    {
        public TagAndFormTools()
        {
        }

        //Set the attributes of the song according to the selected item in its respective Main Form textboxes
        internal void setFormAttributes(string path)
        {
            TagLib.File file = TagLib.File.Create(path);
            clearFormAttributes();

            //Instantiate object with address of selected MP3 file
            if (FormMP3Boss.cBoxTitle.Checked != true)
                FormMP3Boss.tBoxTitle.Text = file.Tag.Title;
            if (FormMP3Boss.cBoxAlbumArtist.Checked != true)
                FormMP3Boss.tBoxAlbumArtist.Text = file.Tag.FirstAlbumArtist;
            //Loop for finding & displaying all contributing artists from MP3 file (array)
            if (FormMP3Boss.cBoxContArtists.Checked != true)
            {
                for (int i = 0; i < file.Tag.Performers.Length; i++)
                {
                    if (i == (file.Tag.Performers.Length - 1))
                    {
                        FormMP3Boss.tBoxContArtists.Text += file.Tag.Performers[i];
                    }
                    else
                        FormMP3Boss.tBoxContArtists.Text += file.Tag.Performers[i] + ";";
                }
            }
            if (FormMP3Boss.cBoxAlbum.Checked != true)
                FormMP3Boss.tBoxAlbum.Text = file.Tag.Album;
            if (FormMP3Boss.cBoxYear.Checked != true)
                FormMP3Boss.tBoxYear.Text = file.Tag.Year.ToString();
            if (FormMP3Boss.cBoxTrackNo.Checked != true)
                FormMP3Boss.tBoxTrackNo.Text = file.Tag.Track.ToString();
            if (FormMP3Boss.cBoxGenre.Checked != true)
            {
                for (int i = 0; i < file.Tag.Genres.Length; i++)
                {
                    if (i == (file.Tag.Genres.Length - 1))
                    {
                        FormMP3Boss.tBoxGenre.Text += file.Tag.Genres[i];
                    }
                    else
                        FormMP3Boss.tBoxGenre.Text += file.Tag.Genres[i] + ";";
                }
            }
        }

        //Clear all text from the Main Form textboxs
        internal void clearFormAttributes()
        {
            if (FormMP3Boss.cBoxTitle.Checked != true)
                FormMP3Boss.tBoxTitle.Clear();
            if (FormMP3Boss.cBoxAlbumArtist.Checked != true)
                FormMP3Boss.tBoxAlbumArtist.Clear();
            if (FormMP3Boss.cBoxContArtists.Checked != true)
                FormMP3Boss.tBoxContArtists.Clear();
            if (FormMP3Boss.cBoxAlbum.Checked != true)
                FormMP3Boss.tBoxAlbum.Clear();
            if (FormMP3Boss.cBoxYear.Checked != true)
                FormMP3Boss.tBoxYear.Clear();
            if (FormMP3Boss.cBoxTrackNo.Checked != true)
                FormMP3Boss.tBoxTrackNo.Clear();
            if (FormMP3Boss.cBoxGenre.Checked != true)
                FormMP3Boss.tBoxGenre.Clear();
        }

        internal void saveChangesToFile(string path)
        {
            TagLib.File file = TagLib.File.Create(path);

            if (FormMP3Boss.tBoxTitle.Text != file.Tag.Title)
                file.Tag.Title = FormMP3Boss.tBoxTitle.Text;

            if (FormMP3Boss.tBoxAlbumArtist.Text != file.Tag.FirstAlbumArtist)
            {
                file.Tag.AlbumArtists = null;
                file.Tag.AlbumArtists = new[] { FormMP3Boss.tBoxAlbumArtist.Text };
            }

            string[] contArtistArr = FormMP3Boss.tBoxContArtists.Text.Split(';'); //Split user entered string into array
            bool contEqual = Enumerable.SequenceEqual(file.Tag.Performers, contArtistArr); //Check if user changed field
            //Copy user's changes to tag
            if (contEqual == false)
            {
                file.Tag.Performers = null; //Clear tag (sorts out bug)
                file.Tag.Performers = contArtistArr;
            }

            if (FormMP3Boss.tBoxAlbum.Text != file.Tag.Album)
                file.Tag.Album = FormMP3Boss.tBoxAlbum.Text;

            if (FormMP3Boss.tBoxYear.Text != file.Tag.Year.ToString())
                file.Tag.Year = uint.Parse(FormMP3Boss.tBoxYear.Text);

            if (FormMP3Boss.tBoxTrackNo.Text != file.Tag.Track.ToString())
                file.Tag.Track = uint.Parse(FormMP3Boss.tBoxTrackNo.Text);

            string[] genre = FormMP3Boss.tBoxGenre.Text.Split(';'); //Split user entered string into array
            bool genreEqual = Enumerable.SequenceEqual(file.Tag.Genres, genre); //Check if user changed field
            //Copy user's changes to tag
            if (genreEqual == false)
            {
                file.Tag.Genres = null; //Clear tag (sorts out bug)
                file.Tag.Genres = genre;
            }

            file.Save();
        }
    }
}
