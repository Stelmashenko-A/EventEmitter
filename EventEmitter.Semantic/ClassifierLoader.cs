using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventEmitter.Semantic
{
    public class ClassifierLoader : IClassifierLoader
    {
        public IEmoticonClassifier LoadEmoticons(string path)
        {

            return new EmoticonClassifier(LoadEmoticonsFromFile(path));
        }

        public IDictionaryClassifier LoadWords(string path)
        {
            var lines = File.ReadAllLines(path);
            var dict = lines.Select(line => line.Split(',')).ToDictionary(strs => strs[0], strs => double.Parse(strs[1].Replace('.', ',')));
            return new DictionaryClassifier(dict);
        }

        public Dictionary<string, int> LoadEmoticonsFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines.Select(line => line.Split('\t')).ToDictionary(strs => strs[0], strs => int.Parse(strs[1])).Where(x => x.Value != 0).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}