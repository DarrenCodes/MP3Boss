using System.Windows.Forms;
using System.Collections.Generic;

namespace MP3Boss
{
    interface IVerify
    {
        string nullTagChecker(string textboxContent, string fileTag);
        string nullTagChecker(List<string> textboxContent, string[] fileTag);

        string checkFormMessage(bool reset = false);
    }
}
