namespace MP3Boss.Models.Models
{
    public class FilePathPair
    {
        public string DisplayText { get; set; }
        public string FilePath { get; set; }

        public FilePathPair() { }
        public FilePathPair(string displayText, string filePath) 
        {
            DisplayText = displayText;
            FilePath = filePath;
        }
    }
}
