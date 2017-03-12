using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries.Registration
{
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
}