using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Controllers
{
    [RoutePrefix("api/Event")]
    public class EventController : ApiController
    {
        private IEventLine _eventLine;

        public EventController(IEventLine eventLine)
        {
            this._eventLine = eventLine;
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
             public string owner { get; set; }
            public string start { get; set; }
            public string duration { get; set; }
            public string price { get; set; }
            public string description { get; set; }
            public string slots { get; set; }
        }
        public EventModel Get(int page)
        {
            var events = _eventLine.Get(page);
            var responce = new EventModel {events = events};
            return responce;
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {
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
