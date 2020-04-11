using System;
using Translator.Models;
using System.IO;
using System.Collections.Generic;

namespace Translator.Models
{
    using uDictionary = Dictionary<string, string>;
    public class Translator
    {
        private readonly uDictionary _dictionary;
        public Translator(string path)
        {
            _dictionary = ReadDicitonary(path);
        }
        private uDictionary ReadDicitonary(string path)
        {
            uDictionary dictionary = new uDictionary();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] pair = line.Split('=');
                    dictionary.Add(pair[0], pair[1]);
                }

            }
            return dictionary;
        }
        public string FindTranslation(string searchWord)
        {
            foreach(KeyValuePair<string, string> pair in _dictionary)
            {
                if (pair.Key == searchWord)
                {
                    return pair.Value;
                }
                if (pair.Value == searchWord)
                {
                    return pair.Key;
                }
            }
            return null;
        }


    }
}
