using System.Windows.Forms;

namespace MP3Boss
{
    class Verify: IVerify
    {
        //Checks if any null tags exist in the mp3 file as well as the form
        public DialogResult nullTagChecker(string textboxContent, string fileTag)
        {
            DialogResult messageInput = default(DialogResult);
            if (fileTag == null)
                fileTag = "";

            if (textboxContent.Length == 0 && fileTag.Length == 0)
                messageInput = checkFormMessage();

            return messageInput;
        }
        public DialogResult nullTagChecker(string textboxContent, string[] fileTag)
        {
            DialogResult messageInput = default(DialogResult);

            if (textboxContent.Length == 0 && fileTag.Length == 0)
                messageInput = checkFormMessage();

            return messageInput;
        }
        //Prompts the user to check the tags loaded in the form or to ignore
        DialogResult checkFormMessage()
        {
            DialogResult dialogResult = MessageBox.Show("All fields not filled. Fill now?"
                + "\nSelecting Abort will re-format using existing tags."
                + "\nSelecting Retry will allow you to edit the problem tag."
                + "\nSelecting Ignore will skip the problem file.", "Important Message", MessageBoxButtons.AbortRetryIgnore);

            return dialogResult;
        }
    }
}
