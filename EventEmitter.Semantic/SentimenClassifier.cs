using System;
using System.Collections.Generic;
using System.Linq;

namespace EventEmitter.Semantic
{
    public interface ISentimenClassifier
    {
        int Classify(string str);
    }

    public class SentimenClassifier : ISentimenClassifier
    {
        protected IEmoticonClassifier EmoticonClassifier { get; set; }
        protected IDictionaryClassifier DictionaryClassifier { get; set; }
        public int Classify(string str)
        {
            List<string> emoticons = DetectEmoticons(str);
            if (emoticons.Any())
            {
                return EmoticonClassifier.Classify(emoticons);
            }
            return DictionaryClassifier.Classify(str.Split(' ').ToList()) >= 0 ? 1 : -1;
        }
        protected List<string> Emoticons = new List<string>() { "}:{", ";)", ":)", ":(" };

        public SentimenClassifier(IEmoticonClassifier emoticonClassifier, IDictionaryClassifier dictionaryClassifier)
        {
            EmoticonClassifier = emoticonClassifier;
            DictionaryClassifier = dictionaryClassifier;
        }

        private int CalcBySegments(List<string> segments)
        {
            throw new NotImplementedException();
        }



        private List<string> DetectEmoticons(string str)
        {
            return Emoticons.Where(str.Contains).ToList();
        }

        private List<string> Segmenting(string str)
        {
            throw new NotImplementedException();
        }
    }
}
