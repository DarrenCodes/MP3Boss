using MP3Boss.Source.Database;
using MP3Boss.Source.Datastructures;
using MP3Boss.Source.File;
using MP3Boss.Source.GUI.Backend;
using MP3Boss.Source.Objects.Requirements;
using MP3Boss.Source.Validation;

namespace MP3Boss.Source.Objects
{
    public abstract class ObjectFactory
    {
        #region Form manager factories
        public static IFormManager GetFormManager(IView gui)
        {
            return new FormManager(gui);
        }
        #endregion

        #region ComboBox Container factories
        public static IFormComboBoxContainer GetNewComboBoxContainer()
        {
            return new ComboBoxesContent();
        }
        public static IFormComboBoxContainer GetNewComboBoxContainer(IFormComboBoxContainer obj)
        {
            return new ComboBoxesContent(obj);
        }
        public static IFormComboBoxContainer GetNewComboBoxContainer(IReadAndWriteable obj)
        {
            return new ComboBoxesContent(obj);
        }
        #endregion

        #region Checkbox container factories
        public static IFormCheckBoxContainer GetNewCheckBoxContainer()
        {
            return new CheckBoxesContent();
        }
        #endregion

        #region Tag library factories
        public static IFileTagTools GetTagLibrary(string file_path)
        {
            return new FileTagTools(file_path);
        }
        #endregion

        #region Verficiation factories
        public static IVerify GetVerifier()
        {
            return new Verify();
        }
        #endregion

        #region Iterator factories
        public static Iterate GetIterator()
        {
            return new Iterator();
        }
        public static Iterate GetIterator(Iterate obj)
        {
            return new Iterator((Iterator)obj);
        }
        public static Iterate GetIterator(string obj)
        {
            return new Iterator(obj);
        }
        #endregion

        #region Audio file manager factories
        public static IAudioFile GetAudioFileManager()
        {
            return new AudioFile();
        }
        #endregion

        #region Database factories
        public static IQuery GetQuerier(string database_path)
        {
            return new Query(database_path);
        }
        public static IDatabaseSuggest GetDatabaseSuggestor(string db_path)
        {
            return new TagSuggest(db_path);
        }
        public static IDatabaseAdd GetDatabaseAdd(string db_path)
        {
            return new TagAdd(db_path);
        }
        #endregion
    }
}
