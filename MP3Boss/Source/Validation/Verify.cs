using MP3Boss.Source.GUI;

namespace MP3Boss.Source.Validation
{
    class Verify: IVerify
    {
        //Checks if any null tags exist in the mp3 file as well as the form
        public string nullTagChecker(string tag)
        {
            string msgBoxResult = null;

            if (tag == null || tag.Length == 0)
                msgBoxResult = checkFormMessage();

            return msgBoxResult;
        }

        //Prompts the user to check the tags loaded in the form or to ignore
        public string checkFormMessage(bool reset = false)
        {
            CheckMessageWindow checkForm = null;
            if (checkForm == null)
                checkForm = new CheckMessageWindow();

            if (reset)
                checkForm.ApplyToAll = false;

            if (!checkForm.ApplyToAll)
                checkForm.ShowDialog();

            return checkForm.MsgBoxResult;
        }
    }
}
