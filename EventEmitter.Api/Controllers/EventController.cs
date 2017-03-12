using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using EventEmitter.Api.Models.Event;
using EventEmitter.Queries.Calendar;
using EventEmitter.Queries.Registration;
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
            var responce = new EventModel {events = events};
            return responce;
        }

        [AllowAnonymous]
        public EventModel Get(int page, string cat)
        {
            var events = string.IsNullOrEmpty(cat)
                ? EventLine.Get(Account, page)
                : EventLine.Get(Account, page, cat);

            var responce = new EventModel {events = events};
            return responce;
        }

        [Authorize(Roles = "CreateEvent")]
        public void Post([FromBody] Event value)
        {
            var @event = Mapper.Map<Event, UserServices.Models.Event>(value);

            EventManager.Create(@event, Account);

        }

        [AllowAnonymous]
        public NamedEvent Get(Guid id)
        {
            return EventManager.Get(Account, id);
        }

        [AllowAnonymous]
        [Route("qwer")]
        public IEnumerable<Queries.Registration.Event> Get([FromUri] UserEventQuery query)
        {
            return QueryBus.Ask<UserEventQuery, IEnumerable<Queries.Registration.Event>>(query);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("cal")]
        public HttpResponseMessage Calendar([FromUri] CalendarQuery query)
        {
            var calendar = QueryBus.Ask<CalendarQuery, string>(query);

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(calendar);
            writer.Flush();
            stream.Position = 0;

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"calendar{query.EventId}.ical"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }
    }
}