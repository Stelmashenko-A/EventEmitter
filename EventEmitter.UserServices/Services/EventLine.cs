using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<NamedEvent> Get(int page = 1)
        {
            int pageSize;
            if (!int.TryParse(_settings.Get("PAGE_SIZE").Value, out pageSize))
            {
                return new List<NamedEvent>();
            }
            var events = _eventRepository.GetNamed(page, pageSize, double.MaxValue);
            return events.Select(@event => _mapper.Map<Storage.Models.Event, NamedEvent>(@event));

        }

        /// <summary>
        /// page counting from 1
        /// </summary>
        /// <param name="page"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public IEnumerable<NamedEvent> Get(int page, Guid start)
        {
            int pageSize;
            if (!int.TryParse(_settings.Get("PAGE_SIZE").Value, out pageSize))
            {
                return null;
            }
            var timeStamp = _eventRepository.Get(start).TimeStamp;
            var events = _eventRepository.GetNamed(page, pageSize, timeStamp);
            return events.Select(@event => _mapper.Map<Storage.Models.Event, NamedEvent>(@event));
        }
    }
}