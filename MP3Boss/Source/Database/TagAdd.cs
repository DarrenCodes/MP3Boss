using System;
using MP3Boss.Source.Datastructures;

namespace MP3Boss.Source.Database
{
    public class TagAdd : IDatabaseAdd
    {
        IQuery tagDB;

        public TagAdd(IQuery tagDB)
        {
            this.tagDB = tagDB;
        }

        public bool AddToDatabase(IFormComboBoxContainer valueToAdd)
        {
            this.addNewArtistRecord(valueToAdd.Artist);

            this.addNewAlbumRecord(valueToAdd.Album, valueToAdd.Year, valueToAdd.Genre.FirstEntry(), valueToAdd.Artist.ToUpper().GetHashCode());

            this.addNewSongRecord(valueToAdd.Title, valueToAdd.Artist.ToUpper().GetHashCode(), valueToAdd.Year, valueToAdd.Genre.FirstEntry(), valueToAdd.Album.ToUpper().GetHashCode(), valueToAdd.TrackNo);

            foreach (string artist in valueToAdd.ContributingArtists)
            {
                this.addNewArtistRecord(artist);
                this.addNewContributingArtists(valueToAdd.Title.ToUpper().GetHashCode(), artist.ToUpper().GetHashCode());
            }

            return true;
        }

        #region Add data to DB queries
        //Methods used to add new data to the Database
        private void addNewArtistRecord(string artistName)
        {
            string query = String.Format("INSERT OR REPLACE INTO Artists (ID, ArtistName) VALUES({0}, \"{1}\")", artistName.ToUpper().GetHashCode(), artistName);

            tagDB.SQLNonQuery(query);
        }
        private void addNewAlbumRecord(string albumName, uint year, string genre, int artistID)
        {
            string query = String.Format("INSERT OR REPLACE INTO Albums (ID, AlbumName, Year, Genre, ArtistID) VALUES ({0}, \"{1}\", {2}, \"{3}\", {4})", albumName.ToUpper().GetHashCode(), albumName, year, genre, artistID);
            tagDB.SQLNonQuery(query);
        }
        private void addNewSongRecord(string songName, int artistID, uint year, string genre, int albumID, uint trackNO)
        {
            string query = String.Format("INSERT OR REPLACE INTO Songs (ID, SongTitle, ArtistID, Year, Genre, AlbumID, TrackNo) VALUES ({0}, \"{1}\", {2}, {3}, \"{4}\", {5}, {6})", songName.ToUpper().GetHashCode(), songName, artistID, year, genre, albumID, trackNO);
            tagDB.SQLNonQuery(query);
        }
        private void addNewContributingArtists(int songID, int artistID)
        {
            string query = String.Format("INSERT OR REPLACE INTO ContributingArtists (SongID, ArtistID) VALUES ({0}, {1})", songID, artistID);
            tagDB.SQLNonQuery(query);
        }
        #endregion
    }
}
