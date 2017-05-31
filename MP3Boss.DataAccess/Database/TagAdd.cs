using System;

namespace MP3Boss.DataAccess.Database
{
    public class TagAdd
    {
        //IQuery tagDB;

        //public TagAdd(string db_path)
        //{
        //    this.tagDB = ObjectFactory.GetQuerier(db_path);
        //}

        //Func<string, int> GetHash = (item) => item.ToUpper().GetHashCode();

        //public bool AddToDatabase(IWindowProperties formPropertiesObject)
        //{
        //    this.addNewArtistRecord(formPropertiesObject.Artist[0]);

        //    this.addNewAlbumRecord(formPropertiesObject.Album[0], formPropertiesObject.Year[0], formPropertiesObject.Genre[0], GetHash(formPropertiesObject.Artist[0]));

        //    this.addNewSongRecord(formPropertiesObject.Title[0], GetHash(formPropertiesObject.Artist[0]), formPropertiesObject.Year[0], formPropertiesObject.Genre[0], GetHash(formPropertiesObject.Album[0]), formPropertiesObject.TrackNo[0]);

        //    foreach (string artist in formPropertiesObject.ContributingArtists[0].Split(';'))
        //    {
        //        this.addNewArtistRecord(artist);
        //        this.addNewContributingArtists(GetHash(formPropertiesObject.Title[0]), GetHash(artist));
        //    }

        //    return true;
        //}

        //#region Add data to DB queries
        ////Methods used to add new data to the Database
        //private void addNewArtistRecord(string artistName)
        //{
        //    string query = String.Format("INSERT OR REPLACE INTO Artists (ID, ArtistName) VALUES({0}, \"{1}\")", GetHash(artistName), artistName);

        //    tagDB.SQLNonQuery(query);
        //}
        //private void addNewAlbumRecord(string albumName, string year, string genre, int artistID)
        //{
        //    string query = String.Format("INSERT OR REPLACE INTO Albums (ID, AlbumName, Year, Genre, ArtistID) VALUES ({0}, \"{1}\", {2}, \"{3}\", {4})", GetHash(albumName), albumName, year, genre, artistID);
        //    tagDB.SQLNonQuery(query);
        //}
        //private void addNewSongRecord(string songName, int artistID, string year, string genre, int albumID, string trackNO)
        //{
        //    string query = String.Format("INSERT OR REPLACE INTO Songs (ID, SongTitle, ArtistID, Year, Genre, AlbumID, TrackNo) VALUES ({0}, \"{1}\", {2}, {3}, \"{4}\", {5}, {6})", GetHash(songName), songName, artistID, year, genre, albumID, trackNO);
        //    tagDB.SQLNonQuery(query);
        //}
        //private void addNewContributingArtists(int songID, int artistID)
        //{
        //    string query = String.Format("INSERT OR REPLACE INTO ContributingArtists (SongID, ArtistID) VALUES ({0}, {1})", songID, artistID);
        //    tagDB.SQLNonQuery(query);
        //}
        //#endregion
    }
}
