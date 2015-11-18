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
        public static IFormManager GetFormManager(IView gui)
        {
            return new FormManager(gui);
        }

        public static IFormComboBoxContainer GetNewComboBoxContainer()
        {
            return new ComboBoxesContent();
        }
        public static IFormComboBoxContainer GetNewComboBoxContainer(IFormComboBoxContainer obj)
        {
            return new ComboBoxesContent(obj);
        }
        public static IFormComboBoxContainer GetNewComboBoxContainer(IQuery obj)
        {
            return new ComboBoxesContent(obj);
        }
        public static IFormComboBoxContainer GetNewComboBoxContainer(IReadAndWriteable obj)
        {
            return new ComboBoxesContent(obj);
        }

        public static IFormCheckBoxContainer GetNewCheckBoxContainer()
        {
            return new CheckBoxesContent();
        }

        public static TagLibrary GetTagLibrary(string file_path)
        {
            return new TagLibrary(file_path);
        }

        public static IVerify GetVerifier()
        {
            return new Verify();
        }

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

        public static IAudioFile GetAudioFileManager()
        {
            return new AudioFile();
        }

        public static IQuery GetQuerier(string database_path)
        {
            return new Query(database_path);
        }
        public static IDatabaseSuggest GetDatabaseSuggestor(IQuery tagDB)
        {
            return new TagSuggest(tagDB);
        }
        public static IDatabaseAdd GetDatabaseAdd(IQuery tagDB)
        {
            return new TagAdd(tagDB);
        }
    }
}
