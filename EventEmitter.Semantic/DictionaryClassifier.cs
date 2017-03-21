using System.Collections.Generic;
using System.Linq;

namespace EventEmitter.Semantic
{
    public class DictionaryClassifier : IDictionaryClassifier
    {
        public DictionaryClassifier(Dictionary<string, double> words)
        {
            Words = words;
        }

        protected Dictionary<string, double> Words { get; set; }
        public double Classify(List<string> strs)
        {
            var strsTmp = strs.Select(x => x.ToLower());
            return Words.Where(x => strsTmp.Contains(x.Key)).Select(x => x.Value).Sum();
        }
    }
}