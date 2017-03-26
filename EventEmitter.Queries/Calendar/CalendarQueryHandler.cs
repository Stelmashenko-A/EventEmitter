using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries.Calendar
{
    public class CalendarQueryHandler : IQueryHandler<CalendarQuery, IEnumerable<Event>>
    {
        protected DateTime Start { get; set; }
        protected DateTime End { get; set; }

        public IEnumerable<Event> Execute(CalendarQuery query)
        {
            Normalize(query);

            using (var db = new EventEmitterDatabase())
            {
                var request = from registration in db.Registrations
                    where registration.UserAccountId == query.UserId
                    join @event in db.Events on registration.EventId equals @event.Id
                    where @event.Start > Start
                          && @event.Start < End
                    orderby @event.Start
                    select
                        new Event
                        {
                            Title = @event.Name,
                            Start = @event.Start,
                            End = @event.Start.AddMinutes(@event.Duration),
                            Description = @event.ShortDescription,
                            EventId = @event.Id
                        };
                return request;
            }
        }

        protected void Normalize(CalendarQuery query)
        {
            if (query.Date == default(DateTime))
            {
                query.Date = DateTime.Now;
            }
            Start = new DateTime(query.Date.Year, query.Date.Month, 1);
            End = Start.AddMonths(1);
        }
    }
}