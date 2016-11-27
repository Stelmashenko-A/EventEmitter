using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.POCO;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class EventLine : IEventLine
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settings;

        public EventLine(IEventRepository eventRepository, IMapper mapper, ISettingRepository settings)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _settings = settings;
        }

        /// <summary>
        /// page counting from 1
        /// </summary>
        /// <param name="user"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<NamedEvent> Get(User user, int page = 1)
        {
            int pageSize;
            if (!int.TryParse(_settings.Get("PAGE_SIZE").Value, out pageSize))
            {
                return new List<NamedEvent>();
            }
            var storedUser = _mapper.Map<User, UserAccount>(user);
            var events = _eventRepository.GetNamed(storedUser, page, pageSize, double.MaxValue);
            return events.Select(@event => _mapper.Map<Storage.Models.Event, NamedEvent>(@event));

        }

        /// <summary>
        /// page counting from 1
        /// </summary>
        /// <param name="user"></param>
        /// <param name="page"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public IEnumerable<NamedEvent> Get(User user,int page, Guid start)
        {
            int pageSize;
            if (!int.TryParse(_settings.Get("PAGE_SIZE").Value, out pageSize))
            {
                return null;
            }
            var timeStamp = _eventRepository.Get(start).TimeStamp;
            var storedUser = _mapper.Map<User, UserAccount>(user);
            var events = _eventRepository.GetNamed(storedUser, page, pageSize, timeStamp);
            return events.Select(@event => _mapper.Map<Storage.Models.Event, NamedEvent>(@event));
        }
    }
}