using MP3Boss.Source.DataStructures;

namespace MP3Boss.Source.Database
{
    public interface IDatabaseSuggest
    {
        void GetSuggestions(IWindowProperties formPropertiesObject);
    }
}
