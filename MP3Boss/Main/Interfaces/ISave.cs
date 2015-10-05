using System.Collections.Generic;
namespace MP3Boss
{
    public interface ISave
    {
        void saveManager(bool applyToAll, bool autoNext, int format, IMainForm iMainForm);
        void searchAndReplace(string find, string replace, List<string> mp3Files, int currentIndex, bool searchAll);
    }
}
