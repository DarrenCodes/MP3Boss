using MP3Boss.Source.Datastructures;
using MP3Boss.Source.Objects;
using System;
using System.Data.SQLite;

namespace MP3Boss.Source.Database
{
    class Query : IQuery
    {
        private SQLiteDataReader readerResult;
        private string path;
        private Iterate contributing_artists;
        private Iterate genres;
        private bool isNewSong = true;

        public Query(string databasePath)
        {
            this.path = databasePath;
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
            this.readerResult = command.ExecuteReader();
            
            return operationWasSuccessful;
        }
        #endregion

        public bool Read()
        {
            return readerResult.Read();
        }

        public bool IsNewSong
        {
            get { return isNewSong; }
            set { isNewSong = value; }
        }

        #region Get Table Attributes
        public string Title
        {
            get { return readerResult["SongTitle"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public string ArtistName
        {
            get { return readerResult["Artist_Name"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public Iterate ContributingArtistName
        {
            get
            {
                if (isNewSong)
                    contributing_artists = ObjectFactory.GetIterator();

                contributing_artists.Add(readerResult["ContArtists_Name"].ToString());

                return contributing_artists;
            }
            set { throw new NotSupportedException(); }
        }
        public string AlbumName
        {
            get { return readerResult["AlbumName"].ToString(); }
            set { throw new NotSupportedException(); }
        }
        public uint SongYear
        {
            get
            {
                uint song_year = 0;
                if (uint.TryParse(readerResult["Year"].ToString(), out song_year))
                    return song_year;
                else
                    return 0;
            }
            set { throw new NotSupportedException(); }
        }
        public uint TrackNo
        {
            get
            {
                uint track_no = 0;
                if (uint.TryParse(readerResult["TrackNo"].ToString(), out track_no))
                    return track_no;
                else
                    return 0;
            }
            set { throw new NotSupportedException(); }
        }
        public Iterate Genre
        {
            get
            {
                if (isNewSong)
                    genres = ObjectFactory.GetIterator();

                genres.Add(readerResult["Genre"].ToString());

                return genres;
            }
            set { throw new NotSupportedException(); }
        }
        #endregion
    }
}
