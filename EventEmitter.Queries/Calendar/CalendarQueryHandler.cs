using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries.Calendar
{
    public class CalendarQueryHandler : IQueryHandler<CalendarQuery, IEnumerable<Event>>
    {
        public IEnumerable<Event> Execute(CalendarQuery query)
        {
            Normalize(query);

            using (var db = new EventEmitterDatabase())
            {
                var request = from registration in db.Registrations
                    where registration.UserAccountId == query.UserId
                    join @event in db.Events on registration.EventId equals @event.Id
                    where @event.Start > query.Start
                          && @event.Start < query.End
                    orderby @event.Start
                    select
                        new Event
                        {
                            Title = @event.Name,
                            Start = @event.Start,
                            End = @event.Start.AddMinutes(@event.Duration),
                            Description = @event.ShortDescription
                        };
                return request;
            }
        }

        protected void Normalize(CalendarQuery query)
        {
            if (query.Start != default(DateTime) && query.Start != default(DateTime)) return;
            var now = DateTime.Now;
            query.Start = new DateTime(now.Year, now.Month, 1);
            query.End = query.Start.AddMonths(1);
        }
    }
}