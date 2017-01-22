using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class RegistrationManager : IRegistrationManager
    {
        public IEnumerable<Registration> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Registration> GetAllRegistered(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Registration> GetAllRegistered(User user, RegistrationType registrationType)
        {
            throw new System.NotImplementedException();
        }
    }
}