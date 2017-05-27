using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MP3Boss.Source.File;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MP3Boss.Tests
{
    [TestClass]
    public class AudioFileTests
    {
        [TestMethod]
        public void TestGetAudioFiles()
        {
            AudioFile file = new AudioFile();
            string[] droppedFiles =
            {
                "D:\\Music\\03. Everything Fell Into Place - Shwa Losben.mp3",
                "D:\\Music\\09. Roundtrip - Oh Yeah, the Future.txt"
            };
            ObservableCollection<string> ListViewAudioFilesList = new ObservableCollection<string>();
            List<string> FullPathAudioFilesList = new List<string>();
            
            ObservableCollection<string> ExpectedListViewAudioFilesList = new ObservableCollection<string>();

            List<string> ExpectedFullPathAudioFilesList = new List<string>();
        }
    }
}
