using System.Collections.Generic;

namespace EventEmitter.Semantic
{
    public interface IEmoticonClassifier
    {
        int Classify(List<string> strs);
    }
}