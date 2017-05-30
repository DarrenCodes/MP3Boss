using MP3Boss.Common.Interfaces;
using MP3Boss.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MP3Boss.Common.Constants;

namespace MP3Boss.Logic.Directory
{
    public class FileDirectoryManipulationLogic : IManipulateFileDirectoryLogic
    {
        IManipulateFileDirectoryDataAccess _manipulateFileDirectoryDAL;

        public FileDirectoryManipulationLogic(IManipulateFileDirectoryDataAccess manipulateFileDirectoryDAL)
        {
            _manipulateFileDirectoryDAL = manipulateFileDirectoryDAL;
        }

        //Gets all Audio files in selected directory(s)
        public List<FilePathPair> GetFiles(string[] droppedPaths, bool performDeepSearch, string fileTypeFilters = null)
        {
            List<string> UnprocessedDroppedItems = droppedPaths.ToList();
            List<FilePathPair> files = new List<FilePathPair>();

            Action<string[]> GetFiles = (filesList) =>
            {
                foreach (string file in filesList.Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")))
                {
                    if (_manipulateFileDirectoryDAL.FileExists(file) && !files.Any(x => x.FilePath == file))
                    {
                        files.Add(new FilePathPair(_manipulateFileDirectoryDAL.GetFileName(file), file));
                        UnprocessedDroppedItems.Remove(file);
                    }
                };
            };

            GetFiles(droppedPaths);

            UnprocessedDroppedItems.RemoveAll(path => !_manipulateFileDirectoryDAL.DirectoryExists(path));

            foreach (string folder in UnprocessedDroppedItems)
                GetFiles(_manipulateFileDirectoryDAL.GetFiles(folder, performDeepSearch));

            return files;
        }

        public FilePathPair Rename(string filePath, IAmFileTags fileTags, int format)
        {
            string formmatedFilename = GenerateFormattedName(filePath, fileTags, format);

            string newFilePath = _manipulateFileDirectoryDAL.GetDirectoryName(filePath) + "\\" + formmatedFilename;

            _manipulateFileDirectoryDAL.RenameFile(filePath, newFilePath);

            return new FilePathPair(_manipulateFileDirectoryDAL.GetFileName(newFilePath), newFilePath);
        }

        private string GenerateFormattedName(string filePath, IAmFileTags fileTags, int format)
        {
            Func<string, string> NullCheck = (item) =>
            {
                if (!(item == null))
                    return item;
                else
                    return "";
            };

            string title = NullCheck(fileTags.Title.Item);
            uint track = uint.Parse(fileTags.TrackNo.Item);
            string artist = fileTags.Artist.Item;

            string fileDirectoryPath = _manipulateFileDirectoryDAL.GetDirectoryName(filePath);

            string formattedFileName = "";

            //Generate formatted filename
            switch (format)
            {
                case 0: //#. Title - Artist     format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            title + " - " + artist + _manipulateFileDirectoryDAL.GetExtension(filePath);

                        break;
                    }
                case 1: //#. Artist - Title     format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            artist + " - " + title + _manipulateFileDirectoryDAL.GetExtension(filePath);

                        break;
                    }
                case 2: //Artist - Title    format
                    {
                        formattedFileName = artist + " - " + title +
                            _manipulateFileDirectoryDAL.GetExtension(filePath);

                        break;
                    }
                case 3: //#. Title      format
                    {
                        formattedFileName = (track < 10 ? "0" : "") + track + ". " +
                            title + _manipulateFileDirectoryDAL.GetExtension(filePath);

                        break;
                    }
                case 4: //Title - Artist      format
                    {
                        formattedFileName = title + " - " +
                            artist + _manipulateFileDirectoryDAL.GetExtension(filePath);

                        break;
                    }
                default:
                    break;
            }

            return formattedFileName;
        }

        public string RemoveInvalideCharachters(string fileName, string replacementChar = "")
        {
            return Regex.Replace(fileName, FileDirectoryConstants.INVALIDE_FILENAME_CHARS, replacementChar);
        }
    }
}
