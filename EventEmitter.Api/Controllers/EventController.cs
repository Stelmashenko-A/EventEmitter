using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using EventEmitter.Api.Models.Event;
using EventEmitter.Commands.AddToBlackList;
using EventEmitter.Commands.AddToWhiteList;
using EventEmitter.Commands.RemoveFromBlackList;
using EventEmitter.Commands.RemoveFromWhiteList;
using EventEmitter.Queries.BlackList;
using EventEmitter.Queries.EventPage;
using EventEmitter.Queries.ICalendar;
using EventEmitter.Queries.Registration;
using EventEmitter.Queries.WhiteList;
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
            var events = string.IsNullOrEmpty(cat)
                ? EventLine.Get(Account, page)
                : EventLine.Get(Account, page, cat);

            var responce = new EventModel { events = events };
            return responce;
        }

        [Authorize(Roles = "CreateEvent")]
        public void Post([FromBody] Event value)
        {
            var @event = Mapper.Map<Event, UserServices.Models.Event>(value);

            EventManager.Create(@event, Account);

        }

        [AllowAnonymous]
        public EventPage Get([FromUri] EventPageQuery query)
        {
            query.UserId = Account.Id;
            return QueryDispatcher.Ask<EventPageQuery, EventPage>(query);
        }

        [AllowAnonymous]
        [Route("qwer")]
        public IEnumerable<Queries.Registration.Event> Get([FromUri] UserEventQuery query)
        {
            return QueryDispatcher.Ask<UserEventQuery, IEnumerable<Queries.Registration.Event>>(query);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("cal")]
        public HttpResponseMessage Calendar([FromUri] IcalendarQuery query)
        {
            var calendar = QueryDispatcher.Ask<IcalendarQuery, string>(query);

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

        [AllowAnonymous]
        [HttpGet]
        [Route("blacklist")]
        public BlackListQueryResponce BlackList([FromUri] BlackListQuery query)
        {
            return QueryDispatcher.Ask<BlackListQuery, BlackListQueryResponce>(query);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("blacklist")]
        public Guid AddToBlackList([FromBody] AddToBlackListCommand command)
        {
            CommandDispatcher.Execute(command);
            return command.Id;
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("blacklist")]
        public IHttpActionResult RemoveFromBlackList([FromBody] RemoveFromBlackListCommand command)
        {
            CommandDispatcher.Execute(command);
            return Ok();
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("whitelist")]
        public WhiteListQueryResponce WhiteList([FromUri] WhiteListQuery query)
        {
            return QueryDispatcher.Ask<WhiteListQuery, WhiteListQueryResponce>(query);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("whitelist")]
        public Guid AddToWhiteList([FromBody] AddToWhiteListCommand command)
        {
            CommandDispatcher.Execute(command);
            return command.Id;
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("whitelist")]
        public IHttpActionResult RemoveFromWhiteList([FromBody] RemoveFromWhiteListCommand command)
        {
            CommandDispatcher.Execute(command);
            return Ok();
        }
    }
}