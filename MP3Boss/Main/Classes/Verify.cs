using System.Windows.Forms;
using System.Collections.Generic;

namespace MP3Boss
{
    class Verify: IVerify
    {
        //Checks if any null tags exist in the mp3 file as well as the form
        public string nullTagChecker(string textboxContent, string fileTag)
        {
            string msgBoxResult = null;

            if (fileTag == null)
                fileTag = "";

            if (textboxContent.Length == 0 && fileTag.Length == 0)
                msgBoxResult = checkFormMessage();

            return msgBoxResult;
        }
        public string nullTagChecker(List<string> textboxContent, string[] fileTag)
        {
            string msgBoxResult = null;

            if (textboxContent.Count == 0 && fileTag.Length == 0)
                msgBoxResult = checkFormMessage();

            return msgBoxResult;
        }

        //Prompts the user to check the tags loaded in the form or to ignore
        public string checkFormMessage(bool reset = false)
        {
            CheckMessageForm checkForm = new CheckMessageForm();

            if (reset)
                checkForm.ApplyToAll = false;

            if (!checkForm.ApplyToAll)
                checkForm.ShowDialog();

            return checkForm.MsgBoxResult;
        }
    }
}
