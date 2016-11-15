using System;
using System.Collections.Generic;
using System.Web.Http;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Event")]
    public class EventController : CommonController
    {
        private IEventLine _eventLine;
        private IEventManager _eventManager;

        public EventController(IEventLine eventLine, IEventManager eventManager)
        {
            this._eventLine = eventLine;
            _eventManager = eventManager;
        }

        // GET: api/Event
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Event/5
        public string Get(Guid id)
        {
            return "value";
        }
        public class EventModel
        {
            public IEnumerable<NamedEvent> events { get; set; } 
      
        }

        public class Event
        {
            public string Owner { get; set; }
            public DateTime Start { get; set; }
            public string Name { get; set; }
            public string Duration { get; set; }
            public string Price { get; set; }
            public string Description { get; set; }
            public string Slots { get; set; }
        }

        [AllowAnonymous]
        public EventModel Get(int page)
        {
            var events = _eventLine.Get(page);
            var responce = new EventModel {events = events};
            return responce;
        }
        // POST: api/Event
        public async void Post([FromBody]Event value)
        {var @event = Mapper.Map<Event, UserServices.Models.Event>(value);

            _eventManager.Create(@event,Account);

        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
