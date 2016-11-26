using System;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IRegistrator
    {
        bool TryRegister(User user, Guid eventId, RegistrationType registrationType);
        void RemoveRegistration(User user, Event selectedEvent);
    }
}