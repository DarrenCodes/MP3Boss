using System.Windows.Forms;

namespace MP3Boss
{
    interface IVerify
    {
        DialogResult nullTagChecker(string textboxContent, string fileTag);
        DialogResult nullTagChecker(string textboxContent, string[] fileTag);
    }
}
