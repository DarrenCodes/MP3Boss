using MP3Boss.Source.DataStructures;
using MP3Boss.Source.Objects;
using System;
using System.Collections.ObjectModel;

namespace MP3Boss.Source.Database
{
    public class TagSuggest : IDatabaseSuggest
    {
        IQuery tagDB;

        public TagSuggest(string db_path)
        {
            this.tagDB = ObjectFactory.GetQuerier(db_path);
        }

        private string GetSQLQuery(IWindowProperties currentValues)
        {
            string sqlQuery = null;
            bool isFirstCondition = true;


            string sqlSELECTQuery = "SELECT Songs.SongTitle, "
                                    + "art.ArtistName AS Artist_Name, "
                                    + "contArt.ArtistName AS ContArtists_Name, "
                                    + "Albums.AlbumName, "
                                    + "Songs.Year, "
                                    + "Songs.TrackNo, "
                                    + "Songs.Genre ";
            string sqlFROMQuery = "FROM ContributingArtists "
                                + "INNER JOIN Songs ON Songs.ID = ContributingArtists.SongID "
                                + "INNER JOIN Albums ON Albums.ID = Songs.AlbumID "
                                + "INNER JOIN Artists AS art ON art.ID = Songs.ArtistID "
                                + "INNER JOIN Artists AS contArt ON contArt.ID = ContributingArtists.ArtistID ";
            string sqlWHEREQuery = "";

            Action<ObservableCollection<string>, string, bool> generateQuery = (property, columnName, loop) =>
            {
                if (property.Count > 0)
                {
                    if (isFirstCondition)
                        sqlWHEREQuery += String.Format("WHERE (UPPER(" + columnName + ") LIKE UPPER('{0}') ", property[0]);
                    else
                        sqlWHEREQuery += String.Format("AND (UPPER(" + columnName + ") LIKE UPPER('{0}') ", property[0]);

                    if (loop)
                    {
                        foreach (string artist in property[0].Split(';'))
                        {
                            sqlWHEREQuery += String.Format("OR UPPER(" + columnName + ") LIKE UPPER('{0}') ", artist);
                        }
                    }
                    sqlWHEREQuery += ")";

                    isFirstCondition = false;
                }
            };

            generateQuery(currentValues.Title, "Songs.SongTitle", false);
            generateQuery(currentValues.Artist, "art.ArtistName", false);
            generateQuery(currentValues.ContributingArtists, "contArt.ArtistName", true);
            generateQuery(currentValues.Album, "Albums.AlbumName", false);
            generateQuery(currentValues.Year, "Songs.Year", false);
            generateQuery(currentValues.TrackNo, "Songs.TrackNo", false);
            generateQuery(currentValues.Genre, "Songs.Genre", false);
            
            sqlQuery = sqlSELECTQuery + sqlFROMQuery + sqlWHEREQuery;

            return sqlQuery;
        }

        public void GetSuggestions(IWindowProperties formPropertiesObject)
        {
            tagDB.ExecuteSQLQuery(this.GetSQLQuery(formPropertiesObject));
            
            while (tagDB.Read())
            {
                tagDB.IsNewSong = true;
                Assign.AssignTo(formPropertiesObject, tagDB, formPropertiesObject);
            }
        }
    }
}
