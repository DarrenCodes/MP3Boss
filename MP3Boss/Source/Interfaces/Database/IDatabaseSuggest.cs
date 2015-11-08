using MP3Boss.Source.Common.Form.Containers;
using System.Collections.Generic;

namespace MP3Boss.Source.Interfaces.Database
{
    public interface IDatabaseSuggest
    {
        List<FormContent.ComboBoxesContent> getSuggestions(FormContent.ComboBoxesContent currentValues);
    }
}
