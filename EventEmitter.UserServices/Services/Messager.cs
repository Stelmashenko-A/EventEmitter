using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    class Messager : IMessager
    {
        public void Send(User to, User @from, Message message)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Message> GetAll(User to)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Message> GetAll(User to, User @from)
        {
            throw new System.NotImplementedException();
        }
    }
}