using System.Collections.Generic;

namespace MP3Boss.Source.Common.Form.Containers
{
    public class FormContent
    {
        public struct ComboBoxesContent
        {
            public string title;
            public string artistName;
            public List<string> contributingArtists;
            public string albumName;
            public uint songYear;
            public uint trackNo;
            public List<string> songGenre;
        }

        public struct CheckBoxesContent
        {
            public bool Title;
            public bool Artist;
            public bool ContArtists;
            public bool Album;
            public bool Year;
            public bool TrackNo;
            public bool Genres;
        }
    }
}
