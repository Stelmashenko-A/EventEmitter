using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class EventManager : IEventManager
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public EventManager(IEventRepository eventRepository, IMapper mapper, IUserAccountRepository userAccountRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _userAccountRepository = userAccountRepository;
        }

        public void Create(Event obj)
        {
            if (!CanCreate(obj.Creator)) return;

            var storedEvent = _mapper.Map<Event, Storage.POCO.Event>(obj);
            _eventRepository.Insert(storedEvent);
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
            _eventRepository.Get()
        }

    
    }
}