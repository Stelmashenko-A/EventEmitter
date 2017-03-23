using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;
using EventEmitter.Storage.POCO.Enums;

namespace EventEmitter.Queries.Registration
{
    public class UserEventQueryHandler : IQueryHandler<UserEventQuery, IEnumerable<Event>>
    {
        public IEnumerable<Event> Execute(UserEventQuery query)
        {
            Normalize(query);

            using (var db = new EventEmitterDatabase())
            {
                var request = from registration in db.Registrations
                              where registration.UserAccountId == query.UserId
                              where !query.OnlyInterested || registration.Type == RegistrationType.Interested
                              where !query.OnlyGo || registration.Type == RegistrationType.Go

                              join @event in db.Events on registration.EventId equals @event.Id
                              where !query.OnlyNext || @event.Start > DateTime.Now
                              where !query.OnlyInterested || @event.Start < DateTime.Now

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
                return request; //.Skip(query.Page*query.PageSize).Take(query.Page);
            }
        }

        protected void Normalize(UserEventQuery query)
        {
            if (query.OnlyInterested && query.OnlyGo)
            {
                query.OnlyInterested = false;
                query.OnlyGo = false;
            }
            if (query.OnlyNext && query.OnlyPast)
            {
                query.OnlyNext = false;
                query.OnlyPast = false;
            }
        }
    }
}