using System;
using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetAll(Guid @event);
    }
}