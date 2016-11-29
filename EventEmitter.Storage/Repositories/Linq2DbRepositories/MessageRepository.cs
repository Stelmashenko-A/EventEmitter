using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public IEnumerable<Message> GetAll(Guid @event)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Messages
                            where item.EventId==@event
                            select item;

                return query.AsEnumerable();
            }
        }
    }
}