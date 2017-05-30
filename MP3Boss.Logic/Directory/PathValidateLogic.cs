using MP3Boss.Common.Constants;
using System.Text.RegularExpressions;

namespace MP3Boss.Logic.Directory
{
    public class PathValidateLogic
    {
        public bool IsValidFileName(string fileName)
        {

            if (string.IsNullOrEmpty(fileName.Trim())
                || Regex.IsMatch(fileName, FileDirectoryConstants.INVALIDE_FILENAME_CHARS))
                return false;
            else
                return true;
        }
    }
}
