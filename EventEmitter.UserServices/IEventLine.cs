using System;
using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IEventLine
    {
        IEnumerable<NamedEvent> Get(int page);
        IEnumerable<NamedEvent> Get(int page, Guid start);
    }
}
