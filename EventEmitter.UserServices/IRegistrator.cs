using System;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IRegistrator
    {
        bool TryRegister(User user, Guid eventId, RegistrationType registrationType);
        bool TryRemoveRegistration(User user, Guid selectedEvent);
    }
}