using System.Collections.Generic;

namespace MP3Boss.Source.Interfaces.Validate
{
    interface IVerify
    {
        string nullTagChecker(string tags);
        string nullTagChecker(List<string> tags);

        string checkFormMessage(bool reset = false);
    }
}
