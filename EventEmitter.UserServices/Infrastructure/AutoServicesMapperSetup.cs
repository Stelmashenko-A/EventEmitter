using System;
using System.Collections.Generic;
using AutoMapper;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Infrastructure
{
    public class AutoMapperServicesSetup
    {
        public void Setup(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Contact, Storage.POCO.Contact>();
            cfg.CreateMap<Storage.POCO.Contact, Contact>();

            cfg.CreateMap<Event, Storage.POCO.Event>();
            cfg.CreateMap<Storage.POCO.Event, Event>();

            cfg.CreateMap<Message, Storage.POCO.Message>();
            cfg.CreateMap<Storage.POCO.Message, Message>();

            cfg.CreateMap<Registration, Storage.POCO.Registration>();
            cfg.CreateMap<Storage.POCO.Registration, Registration>();

            cfg.CreateMap<User, Storage.POCO.UserAccount>();
            cfg.CreateMap<Storage.POCO.UserAccount, User>();

            cfg.CreateMap<Claim, Storage.POCO.Enums.Claim>();
            cfg.CreateMap<Storage.POCO.Enums.Claim, Claim>();

            cfg.CreateMap<Message, Storage.POCO.Message>();
            cfg.CreateMap<Storage.POCO.Message, Message>();

            cfg.CreateMap<NamedEvent, Storage.Models.Event>();
            cfg.CreateMap<Storage.Models.Event, NamedEvent>();

            cfg.CreateMap<RegistrationType, Storage.POCO.Enums.RegistrationType>();
            cfg.CreateMap<Storage.POCO.Enums.RegistrationType, RegistrationType>();

            cfg.CreateMap<Category, Storage.POCO.Category>();
            cfg.CreateMap<Storage.POCO.Category, Category>();
            cfg.CreateMap<Dictionary<Guid, List<Storage.POCO.Enums.Claim>>, Dictionary<Guid, List<Claim>>>();
        }
    }
}
