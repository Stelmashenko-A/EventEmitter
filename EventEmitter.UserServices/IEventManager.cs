using System;
using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IEventManager
    {
        void Create(Event obj, User owner);
        void Delete(Event obj);
        void Open(Event obj);
        void Close(Event obj);

        IEnumerable<Event> Get(User user);
        IEnumerable<Event> Get(User user, EventState state);
        IEnumerable<User> Get(Event obj);
        IEnumerable<User> Get(Event obj, RegistrationType registrationType);

        NamedEvent Get(Guid eventGuid);
    }
}