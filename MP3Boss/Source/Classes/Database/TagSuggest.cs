using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MP3Boss.Source.Common.Form.Containers;
using MP3Boss.Source.Interfaces.Database;

namespace MP3Boss.Source.Classes.Database
{
    public class TagSuggest : IDatabaseSuggest
    {
        private FormContent.ComboBoxesContent fillFormComboBoxesStruct(FormContent.ComboBoxesContent singleResult, SQLiteDataReader queryResult, bool firstIteration)
        {
            if (singleResult.title != queryResult["SongTitle"].ToString())
                singleResult.title = queryResult["SongTitle"].ToString();
            if (singleResult.artistName != queryResult["Artist_Name"].ToString())
                singleResult.artistName = queryResult["Artist_Name"].ToString();

            bool alreadyAdded = false;
            if (firstIteration)
            {
                singleResult.contributingArtists = new List<string>();
                singleResult.contributingArtists.Add(queryResult["ContArtists_Name"].ToString());
            }
            else
            {
                foreach (string item in singleResult.contributingArtists)
                {
                    if (item == queryResult["ContArtists_Name"].ToString())
                    {
                        alreadyAdded = true;
                        break;
                    }
                }
                if (alreadyAdded == false)
                    singleResult.contributingArtists.Add(queryResult["ContArtists_Name"].ToString());
            }

            if (singleResult.albumName != queryResult["AlbumName"].ToString())
                singleResult.albumName = queryResult["AlbumName"].ToString();
            if (singleResult.songYear != uint.Parse(queryResult["Year"].ToString()))
                singleResult.songYear = uint.Parse(queryResult["Year"].ToString());
            if (singleResult.trackNo != uint.Parse(queryResult["TrackNo"].ToString()))
                singleResult.trackNo = uint.Parse(queryResult["TrackNo"].ToString());

            alreadyAdded = false;
            if (firstIteration)
            {
                singleResult.songGenre = new List<string>();
                singleResult.songGenre.Add(queryResult["Genre"].ToString());
            }
            else
            {
                foreach (string item in singleResult.songGenre)
                {
                    if (item == queryResult["Genre"].ToString())
                    {
                        alreadyAdded = true;
                        break;
                    }
                }
                if (alreadyAdded == false)
                    singleResult.songGenre.Add(queryResult["Genre"].ToString());
            }
            return singleResult;
        }

        private string getSQLQuery(FormContent.ComboBoxesContent currentValues)
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

            if (currentValues.title != "")
            {
                sqlWHEREQuery += String.Format("WHERE UPPER(Songs.SongTitle) LIKE UPPER('{0}') ", currentValues.title);
                isFirstCondition = false;
            }
            if (currentValues.artistName != "")
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE UPPER(art.ArtistName) LIKE UPPER('{0}') ", currentValues.artistName);
                else
                    sqlWHEREQuery += String.Format("AND UPPER(art.ArtistName) LIKE UPPER('{0}') ", currentValues.artistName);

                isFirstCondition = false;
            }
            if (currentValues.contributingArtists != null && currentValues.contributingArtists.Count != 0)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE (UPPER(contArt.ArtistName) LIKE UPPER('{0}') ", currentValues.contributingArtists[0]);
                else
                    sqlWHEREQuery += String.Format("AND (UPPER(contArt.ArtistName) LIKE UPPER('{0}') ", currentValues.contributingArtists[0]);

                if (currentValues.contributingArtists.Count > 1)
                {
                    foreach (string item in currentValues.contributingArtists)
                    {
                        sqlWHEREQuery += String.Format("OR UPPER(contArt.ArtistName) LIKE UPPER('{0}') ", item);
                    }
                }
                sqlWHEREQuery += ")";

                isFirstCondition = false;
            }
            if (currentValues.albumName != "")
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE UPPER(Albums.AlbumName) LIKE UPPER('{0}') ", currentValues.albumName);
                else
                    sqlWHEREQuery += String.Format("AND UPPER(Albums.AlbumName) LIKE UPPER('{0}') ", currentValues.albumName);

                isFirstCondition = false;
            }
            if (currentValues.songYear >= 1000)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.Year = {0} ", currentValues.songYear);
                else
                    sqlWHEREQuery += String.Format("AND Songs.Year = {0} ", currentValues.songYear);

                isFirstCondition = false;
            }
            if (currentValues.trackNo >= 1)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.TrackNo = {0} ", currentValues.trackNo);
                else
                    sqlWHEREQuery += String.Format("AND Songs.TrackNo = {0} ", currentValues.trackNo);

                isFirstCondition = false;
            }
            if (currentValues.songGenre != null && currentValues.songGenre.Count != 0)
            {
                if (isFirstCondition)
                    sqlWHEREQuery += String.Format("WHERE UPPER(Songs.Genre) LIKE UPPER('{0}')", currentValues.songGenre[0]);
                else
                    sqlWHEREQuery += String.Format("AND UPPER(Songs.Genre) LIKE UPPER('{0}') ", currentValues.songGenre[0]);

                isFirstCondition = false;
            }

            sqlQuery = sqlSELECTQuery + sqlFROMQuery + sqlWHEREQuery;

            return sqlQuery;
        }

        public List<FormContent.ComboBoxesContent> getSuggestions(FormContent.ComboBoxesContent currentValues)
        {
            IDatabase database = new TagDB(Properties.Settings.Default.DatabasePath);
            SQLiteDataReader queryResult = database.executeSQLQuery(this.getSQLQuery(currentValues));

            FormContent.ComboBoxesContent singleResult = new FormContent.ComboBoxesContent();
            List<FormContent.ComboBoxesContent> allResults = new List<FormContent.ComboBoxesContent>();


            string oldTitle = "";
            string newTitle = "";
            //Populate list with all relevant records from database
            while (queryResult.Read())
            {
                oldTitle = newTitle;
                newTitle = queryResult["SongTitle"].ToString();

                if (newTitle != oldTitle && oldTitle != "")
                {
                    allResults.Add(singleResult);
                    singleResult = this.fillFormComboBoxesStruct(singleResult, queryResult, true);
                }
                else if (newTitle != oldTitle)
                    singleResult = this.fillFormComboBoxesStruct(singleResult, queryResult, true);
                else if (newTitle == oldTitle && oldTitle != "")
                    singleResult = this.fillFormComboBoxesStruct(singleResult, queryResult, false);
            }
            allResults.Add(singleResult);
            return allResults;
        }
    }
}
