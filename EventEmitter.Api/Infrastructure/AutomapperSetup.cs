using AutoMapper;
using AutoMapper.Configuration;
using EventEmitter.UserServices.Models;
using User = EventEmitter.Api.Models.User.User;

namespace EventEmitter.Api.Infrastructure
{
    public class AutoMapperSetup
    {
        public IConfigurationProvider Setup()
        {
            var cfg = new MapperConfigurationExpression();
            var autoMapperUserServices = new UserServices.Infrastructure.AutoMapperServicesSetup();
            autoMapperUserServices.Setup(cfg);
            var autoMapperAdminServices = new AdminServices.Infrastructure.AutoMapperServicesSetup();
            autoMapperAdminServices.Setup(cfg);
            AddMaps(cfg);
            return new MapperConfiguration(cfg);
        }

        protected void AddMaps(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Models.Event.Event, Event>();
            cfg.CreateMap<Models.Category.CategoryModel, Category>();
            cfg.CreateMap<Category, Models.Category.CategoryModel>();

            cfg.CreateMap<AdminServices.Models.User, User>();
            cfg.CreateMap<User, AdminServices.Models.User>();

            cfg.CreateMap<AdminServices.Models.UserType, Models.UserType.UserType>();
            cfg.CreateMap<Models.UserType.UserType, AdminServices.Models.UserType>();
        }
    }
}