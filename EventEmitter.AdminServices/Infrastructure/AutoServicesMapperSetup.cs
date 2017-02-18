using AutoMapper;
using EventEmitter.AdminServices.Models;

namespace EventEmitter.AdminServices.Infrastructure
{
    public class AutoMapperServicesSetup
    {
        public void Setup(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, Storage.Models.User>();
            cfg.CreateMap<Storage.Models.User, User>();
        }
    }
}
