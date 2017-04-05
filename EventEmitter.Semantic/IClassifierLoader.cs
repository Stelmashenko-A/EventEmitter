using System.Collections.Generic;

namespace EventEmitter.Semantic
{
    public interface IClassifierLoader
    {
        IEmoticonClassifier LoadEmoticons(string path);
        IDictionaryClassifier LoadWords(string path);
        Dictionary<string, int> LoadEmoticonsFromFile(string path);
    }
}