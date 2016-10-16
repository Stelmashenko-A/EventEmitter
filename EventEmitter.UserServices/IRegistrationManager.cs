using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IRegistrationManager
    {
        IEnumerable<Registration> GetAll();
        IEnumerable<Registration> GetAllRegistered(User user);
        IEnumerable<Registration> GetAllRegistered(User user, RegistrationType registrationType);
    }
}