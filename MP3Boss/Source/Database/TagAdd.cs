using System;

namespace MP3Boss.Source.Database
{
    class TagAdd
    {
        #region Add data to DB queries
        //Methods used to add new data to the Database
        public void addNewArtistRecord(string artistName)
        {
            string query = String.Format("INSERT INTO Artists VALUES {0}", artistName);
           // this.sqlNonQuery(query);
        }
        public void addNewSongRecord(string songName, UInt32 artistID, string albumName, UInt16 trackNO, UInt16 year, string genre)
        {
            string query = String.Format("INSERT INTO Songs VALUES ('{0}', {1}, '{2}', {3}, {4}, {5})", songName, artistID, albumName, trackNO, year, genre);
            //this.sqlNonQuery(query);
        }
        public void addNewAlbumRecord(string albumName, UInt32 artistID, UInt16 year, string genre)
        {
            string query = String.Format("INSERT INTO Albums VALUES ('{0}', {1}, {2}, {3})", albumName, artistID, year, genre);
            //this.sqlNonQuery(query);
        }
        #endregion
    }
}
