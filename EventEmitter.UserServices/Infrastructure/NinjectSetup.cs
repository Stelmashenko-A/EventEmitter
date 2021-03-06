﻿using Ninject;
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
            kernel.Bind<IRegistrator>().To<Registrator>();
            kernel.Bind<IRegistrationRepository>().To<RegistrationRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<IMessager>().To<Messager>();
            kernel.Bind<ICategoryRepository>().To<CategotyRepository>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IClaimManager>().To<ClaimManager>(); 
            kernel.Bind<IUserTypeClaimRepository>().To<UserTypeClaimRepository>();
            /* AutoMapperSetup autoMapperSetup = new AutoMapperSetup();
             var config = autoMapperSetup.Setup();
             var mapper = config.CreateMapper();
             kernel.Bind<IMapper>().ToConstant(mapper);*/
            // A reminder
        }
    }
}
