using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventEmitter.Semantic;

namespace SentimentDetection.Research
{
    class Program
    {
        static void Main(string[] args)
        {
            var classifier = LoadClassifier();
            var t = LoadTweets();
            //var d = t.Where(x => classifier.DetectEmoticons(x.Key).Any()).ToList();
            var i = 0;
            var counter = 0;
            var total = 0;
            Console.WriteLine("qwer");
            var errors = new Dictionary<string, int>();
            var g = 0;
            foreach (var i1 in t)
            {
                if (i1.Value != 1 && i1.Value != 0)
                {
                    g++;
                }
            }
            Console.WriteLine(g);
            foreach (var i1 in t.Take(5000))
            {
                var r = classifier.Classify(i1.Key);
                if (r == i1.Value)
                {
                    counter++;
                }
                
                if (r != i1.Value)
                {
                    //counter++;
                    var e = classifier.DetectEmoticons(i1.Key);
                    foreach (var VARIABLE in e)
                    {
                        if (!errors.ContainsKey(VARIABLE))
                        {
                            errors.Add(VARIABLE, 0);
                        }
                        errors[VARIABLE]++;
                    }

                }
                total++;
                if (total % 1000 == 0)
                {
                    Console.WriteLine(total + " " + ((double)counter / total) * 100.0);
                }

            }
            i++;
        }

        public static SentimenClassifier LoadClassifier()
        {
            IClassifierLoader loader = new ClassifierLoader();
            var pathEmoticons = @"G:\Sentimenst\EmoticonSentimentLexicon.txt";
            var emoticonClassifier = loader.LoadEmoticons(pathEmoticons);


            var pathWords = @"G:\Sentimenst\sentiments.csv";
            var wordsClassifier = loader.LoadWords(pathWords);
            var emoticons = loader.LoadEmoticonsFromFile(pathEmoticons);
            return new SentimenClassifier(emoticonClassifier, wordsClassifier, emoticons.Select(x => x.Key).ToList());
        }

        public static Dictionary<string, int> LoadTweets()
        {
            var path = @"G:\Diplom\Sentiment Analysis Dataset.csv";
            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            var dict = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                var f = line.ToLower();
                var index = f.IndexOf(",", StringComparison.Ordinal);
                f = f.Substring(index + 1);
                var emotions = int.Parse(f.Substring(0, 1));
                index = f.IndexOf(",", StringComparison.Ordinal);
                f = f.Substring(index + 1);
                index = f.IndexOf(",", StringComparison.Ordinal);
                f = f.Substring(index + 1);
                f = f.Trim();
                if (!dict.ContainsKey(f))
                {
                    dict.Add(f.Trim(), emotions);
                }
            }
            return dict;
        }
    }
}
