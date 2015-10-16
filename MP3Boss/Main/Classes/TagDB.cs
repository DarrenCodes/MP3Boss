using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace MP3Boss
{
    public class TagDB
    {
        private string path = null;

        public TagDB(string dbPath)
        {
            path = dbPath;
        }

        private SQLiteConnection connectToDb()
        {
            SQLiteConnection newConnection = null;

            if (File.Exists(path))
            {
                newConnection = new SQLiteConnection("Data Source=" + path + ";Version=3");
                newConnection.Open();
            }

            return newConnection;
        }

        #region Execute queries
        //Queries that require no return value
        private void sqlNonQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(this.connectToDb());
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
        //Queries that require return values
        public SQLiteDataReader executeSQLQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(this.connectToDb());
            command.CommandText = query;

            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }
        #endregion

        #region Add data to DB queries
        //Methods used to add new data to the Database
        public void addNewArtistRecord(string artistName)
        {
            string query = String.Format("INSERT INTO Artists VALUES {0}", artistName);
            this.sqlNonQuery(query);
        }
        public void addNewSongRecord(string songName, UInt32 artistID, string albumName, UInt16 trackNO, UInt16 year, string genre)
        {
            string query = String.Format("INSERT INTO Songs VALUES ('{0}', {1}, '{2}', {3}, {4}, {5})", songName, artistID, albumName, trackNO, year, genre);
            this.sqlNonQuery(query);
        }
        public void addNewAlbumRecord(string albumName, UInt32 artistID, UInt16 year, string genre)
        {
            string query = String.Format("INSERT INTO Albums VALUES ('{0}', {1}, {2}, {3})", albumName, artistID, year, genre);
            this.sqlNonQuery(query);
        }
        #endregion
    }
}
