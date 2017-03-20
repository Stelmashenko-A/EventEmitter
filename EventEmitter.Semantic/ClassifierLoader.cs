using System.IO;
using System.Linq;

namespace EventEmitter.Semantic
{
    public class ClassifierLoader
    {
        public EmoticonClassifier LoadEmoticons(string path)
        {
            var lines = File.ReadAllLines(path);
            var dict = lines.Select(line => line.Split(' ')).ToDictionary(strs => strs[0], strs => int.Parse(strs[1]));
            return new EmoticonClassifier(dict);
        }

        public DictionaryClassifier LoadWords(string path)
        {
            var lines = File.ReadAllLines(path);
            var dict = lines.Select(line => line.Split(',')).ToDictionary(strs => strs[0], strs => double.Parse(strs[1]));
            return new DictionaryClassifier(dict);
        }
    }
}