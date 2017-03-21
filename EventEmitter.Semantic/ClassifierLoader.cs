using System.IO;
using System.Linq;

namespace EventEmitter.Semantic
{
    public class ClassifierLoader : IClassifierLoader
    {
        public IEmoticonClassifier LoadEmoticons(string path)
        {
            var lines = File.ReadAllLines(path);
            var dict = lines.Select(line => line.Split('\t')).ToDictionary(strs => strs[0], strs => int.Parse(strs[1]));
            return new EmoticonClassifier(dict);
        }

        public IDictionaryClassifier LoadWords(string path)
        {
            var lines = File.ReadAllLines(path);
            var dict = lines.Select(line => line.Split(',')).ToDictionary(strs => strs[0], strs => double.Parse(strs[1].Replace('.', ',')));
            return new DictionaryClassifier(dict);
        }
    }
}