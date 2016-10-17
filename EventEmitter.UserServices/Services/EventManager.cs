using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    class EventManager : IEventManager
    {
        public void Create(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public void Open(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public void Close(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Event> Get(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Event> Get(User user, EventState state)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Get(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Get(Event obj, RegistrationType registrationType)
        {
            throw new System.NotImplementedException();
        }
    }
}