using MP3Boss.Common.Interfaces;
using MP3Boss.Models.DTOs;
using System.Collections.Generic;
using System;

namespace MP3Boss.Logic.FileTags
{
    public class FileTagManipulationLogic : IManipulateFileTagsLogic
    {
        IManipulateFileTagsDataAccess _manipulateFileTagsDataAccess;

        public FileTagManipulationLogic(IManipulateFileTagsDataAccess manipulateFileTagsDataAccess)
        {
            _manipulateFileTagsDataAccess = manipulateFileTagsDataAccess;
        }

        public void Load(string filePath, IAmFileTags fileTags)
        {
            Map(fileTags, _manipulateFileTagsDataAccess.Read(filePath));
        }

        public void Save(IAmFileTags fileTags)
        {
            _manipulateFileTagsDataAccess.Write(Map(fileTags));
        }

        public void SearchAndReplace(string filePath, string find, string replacement)
        {
            FileTagsDTO fileTagsDTO = _manipulateFileTagsDataAccess.Read(filePath);

            fileTagsDTO.Title = fileTagsDTO.Title.Replace(find, replacement);
            fileTagsDTO.Artist = fileTagsDTO.Artist.Replace(find, replacement);
            fileTagsDTO.ContributingArtists = fileTagsDTO.ContributingArtists.Replace(find, replacement);
            fileTagsDTO.Album = fileTagsDTO.Album.Replace(find, replacement);
            fileTagsDTO.Genre = fileTagsDTO.Genre.Replace(find, replacement);

            _manipulateFileTagsDataAccess.Write(fileTagsDTO);
        }
        public void SearchAndReplace(List<string> audioFilesList, string find, string replacement)
        {
            foreach (string path in audioFilesList)
                SearchAndReplace(path, find, replacement);
        }

        public void Map(IAmFileTags fileTags, FileTagsDTO fileTagsDTO)
        {
            if (!fileTags.Title.Locked)
                fileTags.Title.Item = fileTagsDTO.Title;
            if (!fileTags.Artist.Locked)
                fileTags.Artist.Item = fileTagsDTO.Artist;
            if (!fileTags.ContributingArtists.Locked)
                fileTags.ContributingArtists.Item = fileTagsDTO.ContributingArtists;
            if (!fileTags.Album.Locked)
                fileTags.Album.Item = fileTagsDTO.Album;
            if (!fileTags.Year.Locked)
                fileTags.Year.Item = fileTagsDTO.Year;
            if (!fileTags.TrackNo.Locked)
                fileTags.TrackNo.Item = fileTagsDTO.TrackNo;
            if (!fileTags.Genre.Locked)
                fileTags.Genre.Item = fileTagsDTO.Genre;
            if (!fileTags.TagArt.Locked)
                fileTags.TagArt.Item = fileTagsDTO.TagArt;
        }

        public FileTagsDTO Map(IAmFileTags fileTags)
        {
            return new FileTagsDTO()
            {
                Title = fileTags.Title.Item,
                Artist = fileTags.Artist.Item,
                ContributingArtists = fileTags.ContributingArtists.Item,
                Album = fileTags.Album.Item,
                Year = fileTags.Year.Item,
                TrackNo = fileTags.TrackNo.Item,
                Genre = fileTags.Genre.Item
            };
        }

        public void Clear()
        {
            _manipulateFileTagsDataAccess.Clear();
        }
    }
}
