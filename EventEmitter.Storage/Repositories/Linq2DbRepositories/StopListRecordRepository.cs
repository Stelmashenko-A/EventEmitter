using System;
using System.Linq;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class StopListRecordRepository : Repository<StopListRecord>, IStopListRecordRepository
    {
        public bool Contains(Guid userAccount, Guid storedEvent)
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.StopListRecords.Any(item => item.EventId == storedEvent
                                               && item.UserAccountId == storedEvent);
            }
        }
    }
}