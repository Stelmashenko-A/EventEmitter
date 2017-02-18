using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using EventEmitter.Api.Authentification;

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
            // A reminder

        }
    }
}