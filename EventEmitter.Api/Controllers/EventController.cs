using System;
using System.Web.Http;
using EventEmitter.Api.Models.Event;
using EventEmitter.Core;
using EventEmitter.Core.Command;
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
        protected readonly ICommandBus CommandBus;
        public EventController(IEventLine eventLine, IEventManager eventManager, ICommandBus commandBus)
        {
            EventLine = eventLine;
            EventManager = eventManager;
            CommandBus = commandBus;
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

            var responce = new EventModel { events = events };
            return responce;
        }

        [Authorize(Roles = "CreateEvent")]
        public void Post([FromBody]Event value)
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
        public NamedEvent Get()
        {
            var command = new SignOnCommand();
            CommandBus.Execute(command);
            return new NamedEvent();
        }
    }
}
