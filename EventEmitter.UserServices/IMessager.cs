using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IMessager
    {
        void Send(User to, User from, Message message);
        IEnumerable<Message> GetAll(User to);
        IEnumerable<Message> GetAll(User to, User from);
    }
}