using System;
using System.Data.SQLite;

namespace MP3Boss.Source.Database
{
    class Query : IQuery
    {
        private SQLiteDataReader readerResult;
        private string path;

        public Query(string path)
        {
            this.path = path;
            IsNewSong = true;
        }

        private static SQLiteConnection ConnectToDB(string path)
        {
            SQLiteConnection newConnection = null;
            if (System.IO.File.Exists(path))
            {
                newConnection = new SQLiteConnection("Data Source=" + path + ";Version=3");
                newConnection.Open();
            }

            return newConnection;
        }

        #region Execute queries
        //Queries that require no return value
        public bool SQLNonQuery(string query)
        {
            bool operationWasSuccessful = false;

            SQLiteCommand command = new SQLiteCommand(ConnectToDB(path));
            command.CommandText = query;
            command.ExecuteNonQuery();

            return operationWasSuccessful;
        }
        //Queries that require return values
        public bool ExecuteSQLQuery(string query)
        {
            bool operationWasSuccessful = false;

            SQLiteCommand command = new SQLiteCommand(ConnectToDB(path));
            command.CommandText = query;

            readerResult = command.ExecuteReader();

            return operationWasSuccessful;
        }
        #endregion

        public bool Read()
        {
            return readerResult.Read();
        }

        public bool IsNewSong { get; set; }

        #region Get Table Attributes
        public string Title
        {
            get { return readerResult["SongTitle"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string Artist
        {
            get { return readerResult["Artist_Name"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string ContributingArtists
        {
            get { return readerResult["ContArtists_Name"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string Album
        {
            get { return readerResult["AlbumName"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string Year
        {
            get { return readerResult["Year"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string TrackNo
        {
            get { return readerResult["TrackNo"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string Genre
        {
            get { return readerResult["Genre"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        #endregion
    }
}
