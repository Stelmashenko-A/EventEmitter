using AutoMapper;
using AutoMapper.Configuration;
using EventEmitter.UserServices.Infrastructure;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Infrastructure
{
    public class AutoMapperSetup
    {
        public IConfigurationProvider Setup()
        {
            var cfg = new MapperConfigurationExpression();
            var autoMapperServices = new AutoMapperServicesSetup();
            autoMapperServices.Setup(cfg);
            AddMaps(cfg);
            return new MapperConfiguration(cfg);
        }

        protected void AddMaps(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Models.Event.Event, Event>();
        }
    }
}