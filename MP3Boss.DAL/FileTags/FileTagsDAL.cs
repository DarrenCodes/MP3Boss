using MP3Boss.Common.Interfaces;
using MP3Boss.Models.DTOs;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MP3Boss.DAL.FileTags
{
    public class FileTagsDAL : IManipulateFileTagsDAL
    {
        TagLib.File audioFile;
        string filePath;

        private void OpenTagReader(string filePath)
        {
            this.filePath = filePath;

            if (File.Exists(filePath))
                audioFile = TagLib.File.Create(filePath);
        }

        public FileTagsDTO Read(string filePath)
        {
            OpenTagReader(filePath);

            FileTagsDTO fileTags = new FileTagsDTO();

            fileTags.Title = audioFile.Tag.Title;
            fileTags.Artist = audioFile.Tag.FirstAlbumArtist;

            char[] filter = { ' ', ';' };
            string contributingArtists = "";
            foreach (string artist in audioFile.Tag.Performers)
            {
                contributingArtists += artist + ";";
            }
            fileTags.ContributingArtists = contributingArtists.TrimEnd(filter);

            fileTags.Album = audioFile.Tag.Album;
            fileTags.Year = audioFile.Tag.Year.ToString();
            fileTags.TrackNo = audioFile.Tag.Track.ToString();

            string genres = "";
            foreach (string genre in audioFile.Tag.Genres)
            {
                genres += genre + "; ";
            }
            fileTags.Genre = genres.TrimEnd(filter);

            if (!(audioFile.Tag.Pictures == null || audioFile.Tag.Pictures.Length == 0))
            {
                BitmapImage image = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(audioFile.Tag.Pictures[0].Data.Data))
                {
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }
                fileTags.TagArt = image;
            }
            else
                fileTags.TagArt = null;

            return fileTags;
        }

        public void Write(FileTagsDTO fileTags)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new InvalidOperationException("Data cannot be written to a path that is not set.");

            audioFile.Tag.Title = fileTags.Title;
            audioFile.Tag.AlbumArtists = new string[1] { fileTags.Artist };
            audioFile.Tag.Performers = fileTags.ContributingArtists.Split(';');
            audioFile.Tag.Album = fileTags.Album;
            audioFile.Tag.Year = uint.Parse(fileTags.Year);
            audioFile.Tag.Track = uint.Parse(fileTags.TrackNo);
            audioFile.Tag.Genres = fileTags.Genre.Split(';');

            audioFile.Save();
        }

        public void Write(FileTagsDTO fileTags, string filePath)
        {
            if (this.filePath != filePath)
                OpenTagReader(filePath);

            Write(fileTags);
        }
    }
}
