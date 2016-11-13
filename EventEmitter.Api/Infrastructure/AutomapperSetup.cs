using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using EventEmitter.Api.Controllers;
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
            cfg.CreateMap<EventController.Event, Event>();
        }
    }
}