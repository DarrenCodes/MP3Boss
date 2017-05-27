using MP3Boss.Common.Interfaces;
using MP3Boss.Models.DTOs;
using System.Collections.Generic;

namespace MP3Boss.Source.File
{
    public class FileTagManipulation : IManipulateFileTagsBLL
    {
        IManipulateFileTagsDAL _manipulateFileTags;

        public FileTagManipulation(IManipulateFileTagsDAL manipulateFileTags)
        {
            _manipulateFileTags = manipulateFileTags;
        }

        public void Load(string filePath, IAmFileTags fileTags)
        {
            Map(fileTags, _manipulateFileTags.Read(filePath));
        }

        public void Save(IAmFileTags fileTags)
        {
            _manipulateFileTags.Write(Map(fileTags));
        }

        public void SearchAndReplace(string filePath, string find, string replacement)
        {
            FileTagsDTO fileTagsDTO = _manipulateFileTags.Read(filePath);

            fileTagsDTO.Title = fileTagsDTO.Title.Replace(find, replacement);
            fileTagsDTO.Artist = fileTagsDTO.Artist.Replace(find, replacement);
            fileTagsDTO.ContributingArtists = fileTagsDTO.ContributingArtists.Replace(find, replacement);
            fileTagsDTO.Album = fileTagsDTO.Album.Replace(find, replacement);
            fileTagsDTO.Genre = fileTagsDTO.Genre.Replace(find, replacement);

            _manipulateFileTags.Write(fileTagsDTO);
        }
        public void SearchAndReplace(List<string> audioFilesList, string find, string replacement)
        {
            foreach (string path in audioFilesList)
                SearchAndReplace(path, find, replacement);
        }

        public void Map(IAmFileTags fileTags, FileTagsDTO fileTagsDTO)
        {
            if (!fileTags.Title.LockedStatus)
                fileTags.Title.Item = fileTagsDTO.Title;
            if (!fileTags.Artist.LockedStatus)
                fileTags.Artist.Item = fileTagsDTO.Artist;
            if (!fileTags.ContributingArtists.LockedStatus)
                fileTags.ContributingArtists.Item = fileTagsDTO.ContributingArtists;
            if (!fileTags.Album.LockedStatus)
                fileTags.Album.Item = fileTagsDTO.Album;
            if (!fileTags.Year.LockedStatus)
                fileTags.Year.Item = fileTagsDTO.Year;
            if (!fileTags.TrackNo.LockedStatus)
                fileTags.TrackNo.Item = fileTagsDTO.TrackNo;
            if (!fileTags.Genre.LockedStatus)
                fileTags.Genre.Item = fileTagsDTO.Genre;
            if (!fileTags.TagArt.LockedStatus)
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
    }
}
