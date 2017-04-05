using System.Linq;
using EventEmitter.Semantic;
using EventEmitter.Storage.Repositories;
using Ninject;
using Ninject.Activation;

namespace EventEmitter.Commands.Infrastructure
{
    /*public class EmoticonClassifierProvider : Provider<IEmoticonClassifier>
    {
        [Inject]
        public ISettingRepository SettingRepository { get; set; }

        protected override IEmoticonClassifier CreateInstance(IContext context)
        {
            IClassifierLoader loader = new ClassifierLoader();
            var pathEmoticons = SettingRepository.Get("EMOTICONS_SENTIMENTS").Value;
            var emoticons = loader.LoadEmoticons(pathEmoticons);
            return emoticons;
        }
    }*/
    public class SentimenClassifierProvider : Provider<ISentimenClassifier>
    {
        [Inject]
        public ISettingRepository SettingRepository { get; set; }

        protected override ISentimenClassifier CreateInstance(IContext context)
        {
            IClassifierLoader loader = new ClassifierLoader();
            var pathEmoticons = SettingRepository.Get("EMOTICONS_SENTIMENTS").Value;
            var emoticonClassifier = loader.LoadEmoticons(pathEmoticons);


            var pathWords = SettingRepository.Get("WORDS_SENTIMENTS").Value;
            var wordsClassifier = loader.LoadWords(pathWords);
            var emoticons = loader.LoadEmoticonsFromFile(pathEmoticons);
            return new SentimenClassifier(emoticonClassifier, wordsClassifier, emoticons.Select(x => x.Key).ToList());
        }
    }
}