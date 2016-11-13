using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.Storage.Repositories.Linq2DbRepositories;
using EventEmitter.UserServices.Services;


namespace EventEmitter.UserServices.Infrastructure
{

    public class NinjectServiceDependencyResolver
    {
        public void AddBindings(IKernel kernel)
        {
            kernel.Bind<IAccountManager>().To<AccountManager>();
            kernel.Bind<IUserAccountRepository>().To<UserAccountRepository>();
            kernel.Bind<ISettingRepository>().To<SettingRepository>();
            kernel.Bind<IEventRepository>().To<EventRepository>();
            kernel.Bind<IEventLine>().To<EventLine>();
            kernel.Bind<IEventManager>().To<EventManager>();
            /* AutoMapperSetup autoMapperSetup = new AutoMapperSetup();
             var config = autoMapperSetup.Setup();
             var mapper = config.CreateMapper();
             kernel.Bind<IMapper>().ToConstant(mapper);*/
            // A reminder
        }
    }
}
