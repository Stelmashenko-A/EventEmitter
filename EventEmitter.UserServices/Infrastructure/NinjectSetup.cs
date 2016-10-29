using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.Storage.Repositories.Linq2DbRepositories;


namespace EventEmitter.UserServices.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IAccountManager>().To<AccountManager>();
            kernel.Bind<IUserAccountRepository>().To<UserAccountRepository>();
            kernel.Bind<ISettingRepository>().To<SettingRepository>();
            AutoMapperSetup autoMapperSetup = new AutoMapperSetup();
            // A reminder
            var config = autoMapperSetup.Setup();
            var mapper = config.CreateMapper();
            kernel.Bind<IMapper>().ToConstant(mapper);
        }
    }
}
