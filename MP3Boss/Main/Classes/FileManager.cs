using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MP3Boss
{
    class FileManager : IFileManager
    {
        //Gets all MP3 files in selected directory(s)
        public List<string> getMP3Files(string[] dropedFiles)
        {
            List<string> MP3Files = new List<string>();
            string path = null;

            //List of all items dropped in the list view that are folders
            List<string> subdirectories = new List<string>();
            foreach (string item in dropedFiles)
            {
                if (Directory.Exists(item))
                    subdirectories.Add(item);
            }

            //Message prompt asking the user if subdirectories should be searched for MP3 files and included as well
            DialogResult subDirectorySelection = default(DialogResult);
            if (subdirectories.Count > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButtons.YesNo);

            //This section of code will search and extract all MP3 files from the given directories

            List<string> extractedMP3Files = null;
            foreach (string item in subdirectories)
            {
                path = item;
                if (subDirectorySelection == DialogResult.Yes)
                    extractedMP3Files = (Directory.GetFiles(item, "*.*", SearchOption.AllDirectories)).Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")).ToList();
                else if (subDirectorySelection == DialogResult.No)
                    extractedMP3Files = (Directory.GetFiles(item, "*.*")).Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")).ToList();

                foreach (string file in extractedMP3Files)
                {
                    MP3Files.Add(file);
                }
            }

            //This list contains the MP3 files which were dropped directly onto the list view
            List<string> selectedMP3Files = dropedFiles.Where(item => item.EndsWith(".mp3") || item.EndsWith(".m4a")).ToList();

            //This will add the selectedMP3Files to the MP3Files list
            MP3Files = (MP3Files.Concat(selectedMP3Files)).ToList();

            return MP3Files;
        }

        //Renames the mp3Files on the storage device according to the user's preference
        public bool renameMP3File(string originalFile, string newFileName)
        {
            bool successfull = false;

            try
            {
                if (originalFile != newFileName)
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
