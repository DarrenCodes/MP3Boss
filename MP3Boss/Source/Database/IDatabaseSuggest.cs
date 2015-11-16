using MP3Boss.Source.Datastructures;
using System.Collections.Generic;

namespace MP3Boss.Source.Database
{
    public interface IDatabaseSuggest
    {
        List<IFormComboBoxContainer> GetSuggestions(IFormComboBoxContainer currentValues);
    }
}
