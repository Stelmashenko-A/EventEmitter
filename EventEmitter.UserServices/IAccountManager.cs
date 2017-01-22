using System;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IAccountManager
    {
        void Register(User user);
        User GetInfo(Guid id);
        User GetInfo(string loginProvider, string providerKey);
    }
}
