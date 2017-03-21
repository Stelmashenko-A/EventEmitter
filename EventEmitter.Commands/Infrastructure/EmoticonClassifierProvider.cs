using EventEmitter.Semantic;
using EventEmitter.Storage.Repositories;
using Ninject;
using Ninject.Activation;

namespace EventEmitter.Commands.Infrastructure
{
    public class EmoticonClassifierProvider : Provider<IEmoticonClassifier>
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
    }
}