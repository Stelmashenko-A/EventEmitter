namespace EventEmitter.Semantic
{
    public interface IClassifierLoader
    {
        IEmoticonClassifier LoadEmoticons(string path);
        IDictionaryClassifier LoadWords(string path);
    }
}