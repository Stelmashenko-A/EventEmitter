using System.Collections.Generic;
using EventEmitter.AdminServices.Models;

namespace EventEmitter.AdminServices.Interfaces
{
    public interface IUserTypeAdmin
    {
        IEnumerable<UserType> GetAll();
    }
}