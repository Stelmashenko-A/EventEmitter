using System.Collections.Generic;
using System.Linq;

namespace EventEmitter.Semantic
{
    public class EmoticonClassifier : IEmoticonClassifier
    {
        protected Dictionary<string, int> Emoticons { get; set; }

        public EmoticonClassifier(Dictionary<string, int> emoticons)
        {
            Emoticons = emoticons;
        }
        public int Classify(List<string> strs)
        {
            return Emoticons.Where(x => strs.Contains(x.Key)).Select(x => x.Value).Sum();
        }
    }
}