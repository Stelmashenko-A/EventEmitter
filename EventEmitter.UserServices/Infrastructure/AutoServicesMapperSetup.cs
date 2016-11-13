﻿using AutoMapper;
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

            cfg.CreateMap<NamedEvent, Storage.Models.Event>();
            cfg.CreateMap<Storage.Models.Event, NamedEvent>();
        }
    }
}