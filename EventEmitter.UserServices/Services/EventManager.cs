using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.POCO;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;
using Event = EventEmitter.UserServices.Models.Event;
using RegistrationType = EventEmitter.UserServices.Models.RegistrationType;

namespace EventEmitter.UserServices.Services
{
    public class EventManager : IEventManager
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISettingRepository _settings;
        private readonly IMapper _mapper;

        public EventManager(IEventRepository eventRepository, IMapper mapper, IUserAccountRepository userAccountRepository, ISettingRepository settings)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _settings = settings;
        }

        public void Create(Event obj, User creator)
        {
            if (!CanCreate(creator)) return;
            obj.Creator = creator;
            obj.TimeStamp = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            obj.EventTypeId = new Guid(_settings.Get("DEFAULT_EVENT_TYPE").Value);
            var storedEvent = _mapper.Map<Event, Storage.POCO.Event>(obj);
            storedEvent.EventCreatorId = creator.Id;
            _eventRepository.Insert(storedEvent);
            obj.Id = storedEvent.Id;
        }

        protected bool CanCreate(User creator)
        {
            return true;
        }

        public void Delete(Event obj)
        {
            if (!CanDelete(obj.Creator)) return;

            var storedEvent = _mapper.Map<Event, Storage.POCO.Event>(obj);
            _eventRepository.Delete(storedEvent);
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
            var events = _eventRepository.GetCreated(_mapper.Map<User, Storage.POCO.UserAccount>(user));
            return events.Select(@event => _mapper.Map<Storage.POCO.Event, Event>(@event));
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
            // _eventRepository.Get()
            throw new System.NotImplementedException();
        }

        public NamedEvent Get(User user, Guid eventGuid)
        {
            var storedUser = _mapper.Map<User, UserAccount>(user);
            var @event = _eventRepository.GetNamed(storedUser, eventGuid);
            return _mapper.Map<Storage.Models.Event, NamedEvent>(@event);
        }
    }
}