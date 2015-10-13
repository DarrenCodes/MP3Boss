using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MP3Boss
{
    class FileManager : IFileManager
    {
        //Gets all Audio files in selected directory(s)
        public List<string> getAudioFiles(string[] dropedFiles)
        {
            List<string> AudioFiles = new List<string>();
            string path = null;

            //List of all items dropped in the list view that are folders
            List<string> subdirectories = new List<string>();
            foreach (string item in dropedFiles)
            {
                if (Directory.Exists(item))
                    subdirectories.Add(item);
            }

            //Message prompt asking the user if subdirectories should be searched for audio files and included as well
            DialogResult subDirectorySelection = default(DialogResult);
            if (subdirectories.Count > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButtons.YesNo);

            //This section of code will search and extract all audio files from the given directories
            List<string> extractedAudioFiles = null;
            foreach (string item in subdirectories)
            {
                path = item;
                if (subDirectorySelection == DialogResult.Yes)
                    extractedAudioFiles = (Directory.GetFiles(item, "*.*", SearchOption.AllDirectories)).Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")).ToList();
                else if (subDirectorySelection == DialogResult.No)
                    extractedAudioFiles = (Directory.GetFiles(item, "*.*")).Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4a")).ToList();

                foreach (string file in extractedAudioFiles)
                {
                    AudioFiles.Add(file);
                }
            }

            //This list contains the audio files which were dropped directly onto the list view
            List<string> selectedAudioFiles = dropedFiles.Where(item => item.EndsWith(".mp3") || item.EndsWith(".m4a")).ToList();

            //This will add the selectedAudioFiles to the AudioFiles list
            AudioFiles = (AudioFiles.Concat(selectedAudioFiles)).ToList();

            return AudioFiles;
        }

        //Renames the audio files on the storage device according to the user's preference
        public bool renameAudioFile(string originalFile, string newFileName)
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
                MessageBox.Show("An unexpected error has occured.\n", "Error!");
            }

            if (successfull)
                return true;
            else
                return false;
        }
    }
}
