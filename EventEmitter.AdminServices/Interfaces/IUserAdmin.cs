using System;
using System.Collections.Generic;
using EventEmitter.AdminServices.Models;

namespace EventEmitter.AdminServices.Interfaces
{
    public interface IUserAdmin
    {
        void UpdateUserType(Guid userId, Guid newUserType);
        IEnumerable<User> GetPage(int page);
    }
}
