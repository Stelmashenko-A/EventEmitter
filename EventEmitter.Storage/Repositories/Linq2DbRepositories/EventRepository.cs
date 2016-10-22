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
    }
}