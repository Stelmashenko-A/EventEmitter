using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EventEmitter.Storage.POCO;
using RegistrationType = EventEmitter.Storage.POCO.Enums.RegistrationType;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public IEnumerable<Event> GetCreated(UserAccount userAccount)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Events
                            where item.EventCreatorId == userAccount.Id
                            select item;
                return query.ToArray();
            }
        }

        public IEnumerable<Event> Get(int page, int pageSize, double timestamp)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Events
                            where item.TimeStamp < timestamp
                            select item;

                return query.Skip((page - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public IEnumerable<Models.Event> GetNamed(UserAccount userAccount, int page, int pageSize, double timestamp)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Events
                            where item.TimeStamp < timestamp
                            select item;

                query = query.Skip((page - 1) * pageSize).Take(pageSize);
                var mappedQuery = from @event in query
                                  from registration in db.Registrations.Where(item => item.EventId == @event.Id && item.UserAccountId == userAccount.Id).DefaultIfEmpty()
                                  from account in db.UserAccounts.Where(item => item.Id == @event.EventCreatorId)
                                  select new Models.Event
                                  {
                                      Id = @event.Id,
                                      Name = @event.Name,
                                      Duration = @event.Duration,
                                      EventTypeId = @event.EventTypeId,
                                      Price = @event.Price,
                                      Slots = @event.Slots,
                                      Start = @event.Start,
                                      TimeStamp = @event.TimeStamp,
                                      Author = account.Name,
                                      Image = @event.Image,
                                      Description = @event.Description,
                                      Type = registration == null ? RegistrationType.None : registration.Type
                                  };
                return mappedQuery.ToArray();

            }
        }

        public Models.Event GetNamed(UserAccount userAccount, Guid id)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Events
                            where item.Id == id
                            select item;

                var mappedQuery = from @event in query
                                  from registration in db.Registrations.Where(item => item.EventId == @event.Id && item.UserAccountId == userAccount.Id).DefaultIfEmpty()
                                  from account in db.UserAccounts.Where(item => item.Id == @event.EventCreatorId)
                                  select new Models.Event
                                  {
                                      Id = @event.Id,
                                      Name = @event.Name,
                                      Duration = @event.Duration,
                                      EventTypeId = @event.EventTypeId,
                                      Price = @event.Price,
                                      Slots = @event.Slots,
                                      Start = @event.Start,
                                      TimeStamp = @event.TimeStamp,
                                      Author = account.Name,
                                      Image = @event.Image,
                                      Description = @event.Description,
                                      Type = registration.Type
                                  };
                return mappedQuery.FirstOrDefault();
            }
        }
    }
}