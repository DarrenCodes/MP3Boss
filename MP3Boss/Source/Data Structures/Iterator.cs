using System.Collections;
using System.Collections.Generic;

namespace MP3Boss.Source.Datastructures
{
    public class Iterator : Iterate
    {
        Dictionary<int, string> dictionary;

        public Iterator()
        {
            dictionary = new Dictionary<int, string>();
        }
        public Iterator(Iterator obj)
        {
            dictionary = new Dictionary<int, string>(obj.dictionary);
        }
        public Iterator(string obj)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<int, string>();
                Add(obj);
            }
            else
                Add(obj);
        }

        public string FirstEntry()
        {
            string firstItem = string.Empty;
            foreach (string item in dictionary.Values)
            {
                firstItem = item;
                break;
            }
            return firstItem;
        }

        public void Add(string value)
        {
            if (!dictionary.ContainsKey(value.GetHashCode()))
            {
                dictionary.Add(value.GetHashCode(), value);
            }
        }
        public void Remove(string value)
        {
            dictionary.Remove(value.GetHashCode());
        }

        public int Count()
        {
            return dictionary.Count;
        }

        public bool Contains(string item)
        {
            return dictionary.ContainsValue(item);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
