using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MP3Boss
{
    class FileManager : IFileManager
    {
        static List<string> MP3Files = new List<string>();

        //Gets all MP3 files in selected directory(s)
        public List<string> getMP3Files(string[] dropedFiles)
        {
            List<string> subdirectories = dropedFiles.Where(item => !item.Contains(".mp3")).ToList();

            DialogResult userSelection = default(DialogResult);
            if (subdirectories != null && subdirectories.Count > 0)
                userSelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButtons.YesNo);

            List<string> extractedMP3Files = null;
            foreach (string item in subdirectories)
            {
                if (userSelection == DialogResult.Yes)
                    extractedMP3Files = (Directory.GetFiles(item, "*.mp3", SearchOption.AllDirectories)).ToList();
                else if (userSelection == DialogResult.No)
                    extractedMP3Files = (Directory.GetFiles(item, "*.mp3")).ToList();

                foreach (string file in extractedMP3Files)
                {
                    MP3Files.Add(file);
                }
            }

            List<string> selectedMP3Files = dropedFiles.Where(item => item.Contains(".mp3")).ToList();

            MP3Files = (MP3Files.Concat(selectedMP3Files)).ToList();

            IFormManager manageForm = new FormManager();

            return MP3Files;
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
