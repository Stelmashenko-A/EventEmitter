using System;
using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IEventLine
    {
        IEnumerable<NamedEvent> Get(User user, int page);
        IEnumerable<NamedEvent> Get(User user, int page, Guid start);
        IEnumerable<NamedEvent> Get(User user, int page,string categoryCode);
        IEnumerable<NamedEvent> Get(User user, int page, Guid start, string categoryCode);
    }
}
