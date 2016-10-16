using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IRegistrator
    {
        bool TryRegister(User user, Event selectedEvent, RegistrationType registrationType);
        void RemoveRegistration(User user, Event selectedEvent);
    }
}