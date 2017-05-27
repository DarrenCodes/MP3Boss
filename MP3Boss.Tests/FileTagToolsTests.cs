using Microsoft.VisualStudio.TestTools.UnitTesting;
using MP3Boss.Source.File;

namespace MP3Boss.Tests
{
    [TestClass]
    public class FileTagToolsTests
    {
        const string filePath = "";
        FileTagTools fileTagTools;

        public FileTagToolsTests()
        {
            fileTagTools = new FileTagTools(filePath);
        }

        #region Property Tests
        [TestMethod]
        public void Title_Get_Test()
        {

        } 
        #endregion
    }
}
