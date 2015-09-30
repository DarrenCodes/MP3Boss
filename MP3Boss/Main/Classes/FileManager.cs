using System.Windows.Forms;
using System.IO;

namespace MP3Boss
{
    class FileManager: IFileManager
    {
        static string path = null;
        static string[] mp3Files = null;
        //Gets all MP3 files in selected directory(s)
        public string[] getMP3Files(bool directoryIsSet, bool isDeepScan)
        {
            DialogResult result = default(DialogResult);
            
            if (!directoryIsSet)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                result = folderBrowser.ShowDialog(); //Used to store selected path
                path = folderBrowser.SelectedPath;
            }

            if (result == DialogResult.OK || (directoryIsSet && path != ""))
            {
                if (isDeepScan)
                    mp3Files = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories); //Loads all mp3 files from selected path and subdirectories
                else
                    mp3Files = Directory.GetFiles(path, "*.mp3"); //Loads mp3 files from selected path
            }
            return mp3Files;
        }

        //Renames the mp3Files on the storage device according to the user's preference
        public bool renameMP3File(string originalFile, string newFileName)
        {
            bool successfull = false;

            try
            {
                System.IO.File.Move(originalFile, newFileName);
                successfull = true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file at:" + originalFile + " was not found.", "Error!");
            }
            catch (IOException ex)
            {
                MessageBox.Show("An unexpected error has occured.\n" + ex, "Error!");
            }

            if (successfull)
                return true;
            else
                return false;
        }
    }
}
