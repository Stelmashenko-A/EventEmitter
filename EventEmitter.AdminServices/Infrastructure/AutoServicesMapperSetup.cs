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

            cfg.CreateMap<Storage.POCO.UserType, UserType>();
            cfg.CreateMap<UserType, Storage.POCO.UserType>();

            cfg.CreateMap<Storage.Models.UserType, UserType>();
            cfg.CreateMap<UserType, Storage.Models.UserType>();

            cfg.CreateMap<Storage.POCO.Claim, Claim>();
            cfg.CreateMap<Claim, Storage.POCO.Claim>();
        }
    }
}
