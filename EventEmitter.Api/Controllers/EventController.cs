using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace EventEmitter.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EventController : ApiController
    {
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
            public List<Event> events { get; set; } 
      
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
            var e = new Event()
            {
                owner = page.ToString(),
                start = "efe",
                duration = "efw",
                price = "efjef",
                description = "efhi",
                slots = "ehfiu"
            };
            var ev = new EventModel();
            ev.events = new List<Event>();
            ev.events.Add(e);
            return ev;
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
