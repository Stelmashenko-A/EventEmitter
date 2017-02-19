using EventEmitter.AdminServices.Implementation;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Storage.Repositories;
using EventEmitter.Storage.Repositories.Linq2DbRepositories;
using Ninject;

namespace EventEmitter.AdminServices.Infrastructure
{

    public class NinjectServiceDependencyResolver
    {
        public void AddBindings(IKernel kernel)
        {
            
            kernel.Bind<IUserAdmin>().To<UserAdmin>();

            kernel.Bind<IUserTypeRepository>().To<UserTypeRepository>();
            kernel.Bind<IUserTypeAdmin>().To<UserTypeAdmin>();
            /* AutoMapperSetup autoMapperSetup = new AutoMapperSetup();
             var config = autoMapperSetup.Setup();
             var mapper = config.CreateMapper();
             kernel.Bind<IMapper>().ToConstant(mapper);*/
            // A reminder
        }
    }
}
