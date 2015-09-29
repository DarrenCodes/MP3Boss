using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MP3Boss
{
    class FileManager: IFileManager
    {
        static string path = null;
        public string[] getMP3Files(bool directoryIsSet, bool isDeepScan)
        {
            string[] mp3Files = null;
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
                MessageBox.Show(ex.ToString(), "Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }

            if (successfull)
                return true;
            else
                return false;
        }
    }
}
