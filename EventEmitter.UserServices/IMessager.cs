using System;
using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IMessager
    {
        void Send(Guid eventTo, User from, string message);
        IEnumerable<Message> GetAll(Guid eventTo);
        IEnumerable<Message> GetAll(Guid eventTo, User from);
    }
}