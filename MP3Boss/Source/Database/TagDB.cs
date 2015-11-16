using System.Data.SQLite;

namespace MP3Boss.Source.Database
{
    class TagDB
    {
        public SQLiteConnection connectToDB(string path)
        {
            SQLiteConnection newConnection = null;

            if (System.IO.File.Exists(path))
            {
                newConnection = new SQLiteConnection("Data Source=" + path + ";Version=3");
                newConnection.Open();
            }

            return newConnection;
        }
    }
}
