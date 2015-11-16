using MP3Boss.Source.Datastructures;
using MP3Boss.Source.Objects;
using System;
using System.Collections.Generic;

namespace MP3Boss.Source.Database
{
    public class TagSuggest : IDatabaseSuggest
    {
        private IFormComboBoxContainer FillFormComboBoxesStruct(IFormComboBoxContainer singleResult, IQuery queryResult, bool firstIteration)
        {
            return ObjectFactory.GetNewComboBoxContainer(queryResult);
        }

        private string GetSQLQuery(IFormComboBoxContainer currentValues)
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

            if (currentValues.Title != "")
            {
                sqlWHEREQuery += String.Format("WHERE UPPER(Songs.SongTitle) LIKE UPPER('{0}') ", currentValues.Title);
                isFirstCondition = false;
            }
            if (currentValues.Artist != "")
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE UPPER(art.ArtistName) LIKE UPPER('{0}') ", currentValues.Artist);
                else
                    sqlWHEREQuery += String.Format("AND UPPER(art.ArtistName) LIKE UPPER('{0}') ", currentValues.Artist);

                isFirstCondition = false;
            }
            if (currentValues.ContributingArtists != null && currentValues.ContributingArtists.Count() != 0)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE (UPPER(contArt.ArtistName) LIKE UPPER('{0}') ", currentValues.ContributingArtists);
                else
                    sqlWHEREQuery += String.Format("AND (UPPER(contArt.ArtistName) LIKE UPPER('{0}') ", currentValues.ContributingArtists);

                foreach (string artist in currentValues.ContributingArtists)
                {
                    sqlWHEREQuery += String.Format("OR UPPER(contArt.ArtistName) LIKE UPPER('{0}') ", artist);
                }
                sqlWHEREQuery += ")";

                isFirstCondition = false;
            }
            if (currentValues.Album != "")
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE UPPER(Albums.AlbumName) LIKE UPPER('{0}') ", currentValues.Album);
                else
                    sqlWHEREQuery += String.Format("AND UPPER(Albums.AlbumName) LIKE UPPER('{0}') ", currentValues.Album);

                isFirstCondition = false;
            }
            if (currentValues.Year >= 1000)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.Year = {0} ", currentValues.Year);
                else
                    sqlWHEREQuery += String.Format("AND Songs.Year = {0} ", currentValues.Year);

                isFirstCondition = false;
            }
            if (currentValues.TrackNo >= 1)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.TrackNo = {0} ", currentValues.TrackNo);
                else
                    sqlWHEREQuery += String.Format("AND Songs.TrackNo = {0} ", currentValues.TrackNo);

                isFirstCondition = false;
            }
            if (currentValues.Genre != null && currentValues.Genre.Count() != 0)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE UPPER(Songs.Genre) LIKE UPPER('{0}')", currentValues.Genre);
                else
                    sqlWHEREQuery += String.Format("AND UPPER(Songs.Genre) LIKE UPPER('{0}') ", currentValues.Genre);

                isFirstCondition = false;
            }

            sqlQuery = sqlSELECTQuery + sqlFROMQuery + sqlWHEREQuery;

            return sqlQuery;
        }

        public List<IFormComboBoxContainer> GetSuggestions(IFormComboBoxContainer currentValues)
        {
            IQuery query = ObjectFactory.GetQuerier(Properties.Settings.Default.DatabasePath);
            query.ExecuteSQLQuery(this.GetSQLQuery(currentValues));

            IFormComboBoxContainer singleResult = ObjectFactory.GetNewComboBoxContainer();
            List<IFormComboBoxContainer> allResults = new List<IFormComboBoxContainer>();

            string oldTitle = "";
            string newTitle = "";
            bool first_db_result = true;
            //Populate list with all relevant records from database
            while (query.Read())
            {
                oldTitle = newTitle;
                newTitle = query.Title;

                if (first_db_result)
                {
                    query.IsNewSong = true;
                    singleResult = ObjectFactory.GetNewComboBoxContainer(query);
                }
                else if (newTitle != oldTitle)
                {
                    allResults.Add(singleResult);
                    query.IsNewSong = true;
                    singleResult = ObjectFactory.GetNewComboBoxContainer(query);
                }
                else if (newTitle == oldTitle)
                {
                    query.IsNewSong = false;
                    singleResult = ObjectFactory.GetNewComboBoxContainer(query);
                }

                first_db_result = false;
            }
            allResults.Add(singleResult);
            return allResults;
        }
    }
}
