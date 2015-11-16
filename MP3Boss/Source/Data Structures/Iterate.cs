using System.Collections.Generic;

namespace MP3Boss.Source.Datastructures
{
    public static class ConverterExtensions
    {
        public static string[] ToArray(this Iterate list)
        {
            List<string> toList = new List<string>();
            foreach (string item in list)
            {
                toList.Add(item);
            }
            return toList.ToArray();
        }
    }

    public interface Iterate : IEnumerable<string>
    {
        void Add(string value);
        void Remove(string value);
        int Count();
    }
}
