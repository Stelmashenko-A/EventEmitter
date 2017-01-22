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
        protected readonly IEventRepository EventRepository;
        protected readonly IMapper Mapper;
        protected readonly ISettingRepository Settings;

        protected const string PageSize = "PAGE_SIZE";

        public EventLine(IEventRepository eventRepository, IMapper mapper, ISettingRepository settings)
        {
            EventRepository = eventRepository;
            Mapper = mapper;
            Settings = settings;
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
            if (!int.TryParse(Settings.Get(PageSize).Value, out pageSize))
            {
                return new List<NamedEvent>();
            }
            var storedUser = Mapper.Map<User, UserAccount>(user);
            var events = EventRepository.GetNamed(storedUser, page, pageSize, double.MaxValue);
            return events.Select(@event => Mapper.Map<Storage.Models.Event, NamedEvent>(@event));

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
            if (!int.TryParse(Settings.Get(PageSize).Value, out pageSize))
            {
                return null;
            }
            var timeStamp = EventRepository.Get(start).TimeStamp;
            var storedUser = Mapper.Map<User, UserAccount>(user);
            var events = EventRepository.GetNamed(storedUser, page, pageSize, timeStamp);
            return events.Select(@event => Mapper.Map<Storage.Models.Event, NamedEvent>(@event));
        }
    }
}