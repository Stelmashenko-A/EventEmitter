using System;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IStopListRecordRepository : IRepository<StopListRecord>
    {
        bool Contains(Guid userAccount, Guid storedEvent);
    }

}