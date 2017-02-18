using System;
using System.Collections.Generic;
using System.Web.Http;
using EventEmitter.Api.Models.Event;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;
using Event = EventEmitter.Api.Models.Event.Event;

namespace EventEmitter.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Event")]
    public class EventController : CommonController
    {
        protected readonly IEventLine EventLine;
        protected readonly IEventManager EventManager;

        public EventController(IEventLine eventLine, IEventManager eventManager)
        {
            EventLine = eventLine;
            EventManager = eventManager;
        }


        public EventModel Get(int page)
        {
            var events = EventLine.Get(Account, page);


            var responce = new EventModel { events = events };
            return responce;
        }

        [AllowAnonymous]
        public EventModel Get(int page, string cat)
        {
            var events = string.IsNullOrEmpty(cat) ?
                EventLine.Get(Account, page) :
                EventLine.Get(Account, page, cat);

            var responce = new EventModel {events = events};
            return responce;
        }
        
        // POST: api/Event
        [Authorize(Roles = "CreateEvent")]
        public void Post([FromBody]Event value)
        {
            var @event = Mapper.Map<Event, UserServices.Models.Event>(value);

            EventManager.Create(@event,Account);

        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }

        [AllowAnonymous]
        public NamedEvent Get(Guid id)
        {
            return EventManager.Get(Account, id);
        }
    }
}
