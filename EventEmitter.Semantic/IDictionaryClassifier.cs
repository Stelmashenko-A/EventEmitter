using System.Collections.Generic;

namespace EventEmitter.Semantic
{
    public interface IDictionaryClassifier
    {
        double Classify(List<string> strs);
    }
}