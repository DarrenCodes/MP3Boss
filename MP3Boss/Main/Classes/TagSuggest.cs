using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Reflection;
using System.Resources;

namespace MP3Boss
{
    class TagSuggest
    {
        private formComboBoxes fillFormComboBoxesStruct(formComboBoxes singleResult, SQLiteDataReader queryResult, bool firstIteration)
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
            if (singleResult.songYear != queryResult["Year"].ToString())
                singleResult.songYear = queryResult["Year"].ToString();
            if (singleResult.trackNo != queryResult["TrackNo"].ToString())
                singleResult.trackNo = queryResult["TrackNo"].ToString();

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

        private string getSQLQuery(formComboBoxes currentValues)
        {
            string sqlQuery = null;
            bool firstCondition = true;

            string sqlSELECTQuery = "SELECT Songs.SongTitle, "
                                    + "art.ArtistName AS Artist_Name, "
                                    + "contArt.ArtistName AS ContArtists_Name, "
                                    + "Albums.AlbumName, "
                                    + "Songs.Year, "
                                    + "Songs.TrackNo, "
                                    + "Songs.Genre ";
            string sqlFROMQuery = "FROM ContributingArtists, Songs "
                                + "INNER JOIN Albums ON Songs.AlbumID = Albums.ID "
                                + "INNER JOIN Artists AS art ON art.ID = Songs.ArtistID "
                                + "INNER JOIN Artists AS contArt ON contArt.ID = ContributingArtists.ArtistID AND Songs.ID = ContributingArtists.SongID ";
            string sqlWHEREQuery = "";

            if (currentValues.title != "")
            {
                sqlWHEREQuery += String.Format("WHERE Songs.SongTitle = '{0}' ", currentValues.title);
                firstCondition = false;
            }
            if (currentValues.artistName != "")
            {
                if (firstCondition)
                    sqlWHEREQuery += String.Format("WHERE art.ArtistName = '{0}' ", currentValues.artistName);
                else
                    sqlWHEREQuery += String.Format("AND art.ArtistName = '{0}' ", currentValues.artistName);

                firstCondition = false;
            }
            if (currentValues.contributingArtists != null && currentValues.contributingArtists.Count != 0)
            {
                if (firstCondition)
                    sqlWHEREQuery += String.Format("WHERE (contArt.ArtistName='{0}' ", currentValues.contributingArtists[0]);
                else
                    sqlWHEREQuery += String.Format("AND (contArt.ArtistName='{0}' ", currentValues.contributingArtists[0]);

                if (currentValues.contributingArtists.Count > 1)
                {
                    foreach (string item in currentValues.contributingArtists)
                    {
                        sqlWHEREQuery += String.Format("OR contArt.ArtistName='{0}' ", item);
                    }
                }
                sqlWHEREQuery += ")";

                firstCondition = false;
            }
            if (currentValues.albumName != "")
            {
                if (firstCondition)
                    sqlWHEREQuery += String.Format("WHERE Albums.AlbumName = '{0}' ", currentValues.albumName);
                else
                    sqlWHEREQuery += String.Format("AND Albums.AlbumName = '{0}' ", currentValues.albumName);

                firstCondition = false;
            }
            if (currentValues.songYear != "" && currentValues.songYear != "0")
            {
                if (firstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.Year = {0} ", currentValues.songYear);
                else
                    sqlWHEREQuery += String.Format("AND Songs.Year = {0} ", currentValues.songYear);

                firstCondition = false;
            }
            if (currentValues.trackNo != "" && currentValues.trackNo != "0")
            {
                if (firstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.TrackNo = {0} ", currentValues.trackNo);
                else
                    sqlWHEREQuery += String.Format("AND Songs.TrackNo = {0} ", currentValues.trackNo);

                firstCondition = false;
            }
            if (currentValues.songGenre != null && currentValues.songGenre.Count != 0)
            {
                if (firstCondition)
                    sqlWHEREQuery += String.Format("WHERE Songs.Genre = '{0}' ", currentValues.songGenre);
                else
                    sqlWHEREQuery += String.Format("AND Songs.Genre = '{0}' ", currentValues.songGenre);

                firstCondition = false;
            }

            sqlQuery = sqlSELECTQuery + sqlFROMQuery + sqlWHEREQuery;

            return sqlQuery;
        }

        public List<formComboBoxes> getSuggestions(formComboBoxes currentValues)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            TagDB database = new TagDB("TagDB.sqlite");
            SQLiteDataReader queryResult = database.executeSQLQuery(this.getSQLQuery(currentValues));

            formComboBoxes singleResult = new formComboBoxes();
            List<formComboBoxes> allResults = new List<formComboBoxes>();


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
                else if(newTitle != oldTitle)
                    singleResult = this.fillFormComboBoxesStruct(singleResult, queryResult, true);
                else if (newTitle == oldTitle && oldTitle != "")
                    singleResult = this.fillFormComboBoxesStruct(singleResult, queryResult, false);
            }
            allResults.Add(singleResult);
            return allResults;
        }
    }
}
