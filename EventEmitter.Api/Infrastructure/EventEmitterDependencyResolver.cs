using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using EventEmitter.UserServices.Infrastructure;

namespace EventEmitter.Api.Infrastructure
{
    public class EventEmitterDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public EventEmitterDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            var ninjectService = new NinjectServiceDependencyResolver();
            ninjectService.AddBindings(kernelParam);
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
            var autoMapperSetup = new AutoMapperSetup();
            var config = autoMapperSetup.Setup();
            var mapper = config.CreateMapper();
            kernel.Bind<IMapper>().ToConstant(mapper);

            // A reminder

        }
    }
}