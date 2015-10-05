using System.Windows.Forms;

namespace MP3Boss
{
    interface IVerify
    {
        string nullTagChecker(string textboxContent, string fileTag);
        string nullTagChecker(string textboxContent, string[] fileTag);

        string checkFormMessage(bool reset = false);
    }
}
