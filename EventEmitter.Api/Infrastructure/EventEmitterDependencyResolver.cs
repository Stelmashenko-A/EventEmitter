using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using EventEmitter.Api.Authentification;
using EventEmitter.Core;
using EventEmitter.Core.Command;
using Ninject.Extensions.Conventions;

namespace EventEmitter.Api.Infrastructure
{
    public class EventEmitterDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public EventEmitterDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            var ninjectUserService = new UserServices.Infrastructure.NinjectServiceDependencyResolver();
            ninjectUserService.AddBindings(kernelParam);
            var ninjectAdminService = new AdminServices.Infrastructure.NinjectServiceDependencyResolver();
            ninjectAdminService.AddBindings(kernelParam);
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            var autoMapperSetup = new AutoMapperSetup();
            var config = autoMapperSetup.Setup();
            var mapper = config.CreateMapper();
            _kernel.Bind<IMapper>().ToConstant(mapper);
            _kernel.Bind<IPropertyBuilder>().To<PropertyBuilder>();
            _kernel.Bind<IIdentetyBuilder>().To<IdentetyBuilder>();

            var coreAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.GetName().Name == "EventEmitter.Core");
            _kernel.Bind(x => x
                .From(coreAssembly)
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InSingletonScope()));


            var queryAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.GetName().Name == "EventEmitter.Queries");
            _kernel.Bind(x => x
                .From(queryAssembly)
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InSingletonScope()));


            var commandAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.GetName().Name == "EventEmitter.Commands");
            _kernel.Bind(x => x
                .From(commandAssembly)
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InSingletonScope()));

        }
    }
}