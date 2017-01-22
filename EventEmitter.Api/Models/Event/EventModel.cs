using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Models.Event
{
    public class EventModel
    {
        public IEnumerable<NamedEvent> events { get; set; }

    }
}