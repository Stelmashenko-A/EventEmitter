using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;

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

        public IEnumerable<Models.Event> GetNamed(int page, int pageSize, double timestamp)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Events
                            where item.TimeStamp < timestamp
                            select item;

                query = query.Skip((page - 1) * pageSize).Take(pageSize);
                var g = query.ToArray();
                var mappedQuery = from p in query
                       join c in db.UserAccounts on p.EventCreatorId equals c.Id
                       select new Models.Event
                       {
                           Id = p.Id,
                           Duration = p.Duration,
                           EventTypeId = p.EventTypeId,
                           Price = p.Price,
                           Slots = p.Slots,
                           Start = p.Start,
                           TimeStamp = p.TimeStamp,
                           Author = c.Name

                       };
                return mappedQuery.ToArray();

            }
        }
    }
}