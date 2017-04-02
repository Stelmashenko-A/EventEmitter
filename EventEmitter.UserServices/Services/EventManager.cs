using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.POCO;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;
using Event = EventEmitter.UserServices.Models.Event;
using EventType = EventEmitter.Storage.POCO.Enums.EventType;
using RegistrationType = EventEmitter.UserServices.Models.RegistrationType;

namespace EventEmitter.UserServices.Services
{
    public class EventManager : IEventManager
    {
        protected readonly IEventRepository EventRepository;
        protected readonly ISettingRepository Settings;
        protected readonly IMapper Mapper;
        protected readonly ICategoryRepository CategoryRepository;

        protected const string DefaultEventType = "DEFAULT_EVENT_TYPE";

        public EventManager(IEventRepository eventRepository, IMapper mapper, IUserAccountRepository userAccountRepository, ISettingRepository settings, ICategoryRepository categoryRepository)
        {
            EventRepository = eventRepository;
            Mapper = mapper;
            Settings = settings;
            CategoryRepository = categoryRepository;
        }

        public void Create(Event obj, User creator)
        {
            //if (!CanCreate(creator)) return;
            obj.Creator = creator;
            obj.TimeStamp = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            var storedEvent = Mapper.Map<Event, Storage.POCO.Event>(obj);
            storedEvent.EventType = EventType.Default;
            if (obj.Blocked)
            {
                storedEvent.EventType = EventType.UseWhiteList;
            }
            storedEvent.EventCreatorId = creator.Id;
            storedEvent.CategoryId = CategoryRepository.Get(obj.Category).Id;
            EventRepository.Insert(storedEvent);
            obj.Id = storedEvent.Id;
        }

        protected bool CanCreate(User creator)
        {
            return true;
        }

        public void Delete(Event obj)
        {
            if (!CanDelete(obj.Creator)) return;

            var storedEvent = Mapper.Map<Event, Storage.POCO.Event>(obj);
            EventRepository.Delete(storedEvent);
        }

        private bool CanDelete(User creator)
        {
            return true;
        }

        public void Open(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public void Close(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Event> Get(User user)
        {
            var events = EventRepository.GetCreated(Mapper.Map<User, UserAccount>(user));
            return events.Select(@event => Mapper.Map<Storage.POCO.Event, Event>(@event));
        }

        public IEnumerable<Event> Get(User user, EventState state)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Get(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Get(Event obj, RegistrationType registrationType)
        {
            // _eventRepository.Contains()
            throw new System.NotImplementedException();
        }

        public NamedEvent Get(User user, Guid eventGuid)
        {
            var storedUser = Mapper.Map<User, UserAccount>(user);
            var @event = EventRepository.GetNamed(storedUser, eventGuid);
            return Mapper.Map<Storage.Models.Event, NamedEvent>(@event);
        }
    }
}