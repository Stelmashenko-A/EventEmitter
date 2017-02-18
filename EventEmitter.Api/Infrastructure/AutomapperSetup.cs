using AutoMapper;
using AutoMapper.Configuration;
using EventEmitter.UserServices.Models;

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

            cfg.CreateMap<AdminServices.Models.User, Models.User>();
            cfg.CreateMap<Models.User, AdminServices.Models.User>();
        }
    }
}