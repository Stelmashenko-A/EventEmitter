using EventEmitter.Semantic;
using Ninject;

namespace EventEmitter.Commands.Infrastructure
{
    public class NinjectCommandsDependencyResolver
    {
        public void AddBindings(IKernel kernel)
        {
            kernel.Bind<IEmoticonClassifier>().ToProvider<EmoticonClassifierProvider>();
            kernel.Bind<IDictionaryClassifier>().ToProvider<DictionaryClassifierProvider>();
            kernel.Bind<ISentimenClassifier>().To<SentimenClassifier>();
        }
    }
}