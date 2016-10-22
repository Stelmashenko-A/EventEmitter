using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetCreated(UserAccount userAccount); 
    }
}