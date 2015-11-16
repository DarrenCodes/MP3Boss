using MP3Boss.Source.Datastructures;
using MP3Boss.Source.GUI;

namespace MP3Boss.Source.Validation
{
    class Verify: IVerify
    {
        //Checks if any null tags exist in the mp3 file as well as the form
        public string nullTagChecker(string tag)
        {
            string msgBoxResult = null;

            if (tag.Length == 0)
                msgBoxResult = checkFormMessage();

            return msgBoxResult;
        }
        public string nullTagChecker(Iterate tag)
        {
            string msgBoxResult = null;

            if (tag.Count() == 0)
                msgBoxResult = checkFormMessage();

            return msgBoxResult;
        }

        //Prompts the user to check the tags loaded in the form or to ignore
        public string checkFormMessage(bool reset = false)
        {
            CheckMessageForm checkForm = null;
            if (checkForm == null)
                checkForm = new CheckMessageForm();

            if (reset)
                checkForm.ApplyToAll = false;

            if (!checkForm.ApplyToAll)
                checkForm.ShowDialog();

            return checkForm.MsgBoxResult;
        }
    }
}
