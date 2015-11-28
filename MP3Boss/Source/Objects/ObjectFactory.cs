using MP3Boss.Source.Database;
using MP3Boss.Source.DataStructures;
using MP3Boss.Source.File;
using MP3Boss.Source.GUI.Backend;
using MP3Boss.Source.Validation;

namespace MP3Boss.Source.Objects
{
    public abstract class ObjectFactory
    {
        #region Form manager factories
        public static IFormManager GetFormManager(IWindowProperties formPropertiesObject)
        {
            return new FormManager(formPropertiesObject);
        }
        #endregion

        #region Binding Object Factory
        public static IWindowProperties GetBindingObject()
        {
            return new WindowProperties();
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
