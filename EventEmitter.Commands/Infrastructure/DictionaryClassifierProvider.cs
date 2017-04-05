using EventEmitter.Semantic;
using EventEmitter.Storage.Repositories;
using EventEmitter.Storage.Repositories.Linq2DbRepositories;
using Ninject;
using Ninject.Activation;

namespace EventEmitter.Commands.Infrastructure
{
   /* public class DictionaryClassifierProvider : Provider<IDictionaryClassifier>
    {
        [Inject]
        public ISettingRepository SettingRepository { get; set; }

        protected override IDictionaryClassifier CreateInstance(IContext context)
        {
            IClassifierLoader loader = new ClassifierLoader();
            var pathWords = SettingRepository.Get("WORDS_SENTIMENTS").Value;
            var words = loader.LoadWords(pathWords);
            return words;
        }
    }*/
}
