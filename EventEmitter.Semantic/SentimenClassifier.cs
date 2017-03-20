using System;
using System.Collections.Generic;
using System.Linq;

namespace EventEmitter.Semantic
{
    public class SentimenClassifier
    {
        public int Classify(string str)
        {
            List<string> emoticons = DetectEmoticons(str);
            if (emoticons.Any())
            {
                return CalclByEmoticons(emoticons);
            }
            return 1;

        }
        protected List<string> Emoticons = new List<string>() { "}:{", ";)", ":)", ":(" };
        private int CalcBySegments(List<string> segments)
        {
            throw new NotImplementedException();
        }

        private int CalclByEmoticons(List<string> emoticons)
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
