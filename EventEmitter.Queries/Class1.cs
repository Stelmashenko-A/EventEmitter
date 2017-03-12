using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries
{
    public class UserEventQuery : IQuery
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class UserEventQueryHandler : IQueryHandler<UserEventQuery,IEnumerable<Event>>
    {
        public IEnumerable<Event> Execute(UserEventQuery query)
        {
            using (var db = new EventEmitterDatabase())
            {
                var request = from registration in db.Registrations
                    where registration.UserAccountId == query.UserId
                    join @event in db.Events on registration.EventId equals @event.Id

                    orderby @event.Start
                    select
                        new Event
                        {
                            Name = @event.Name,
                            Start = @event.Start,
                            Price = @event.Price,
                            RegistrationType = registration.Type.ToString(),
                            RegistrationId = registration.Id,
                            EventId = @event.Id
                        };
                return request;//.Skip(query.Page*query.PageSize).Take(query.Page);
            }
        }
    }

    public class Event
    {
        public string RegistrationType { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public int Price { get; set; }
        public Guid RegistrationId { get; set; }
        public Guid EventId { get; set; }
    }
}
