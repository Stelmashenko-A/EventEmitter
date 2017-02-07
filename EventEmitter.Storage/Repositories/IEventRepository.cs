using System;
using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetCreated(UserAccount userAccount);
        IEnumerable<Event> Get(int page, int pageSize, double timestamp);
        IEnumerable<Models.Event> GetNamed(UserAccount userAccount, int page, int pageSize, double timestamp);
        IEnumerable<Models.Event> GetNamed(UserAccount userAccount, int page, int pageSize, double timestamp, string categoryCode);
        Models.Event GetNamed(UserAccount userAccount, Guid id);
    }
}