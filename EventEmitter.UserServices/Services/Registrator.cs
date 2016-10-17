using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    class Registrator : IRegistrator
    {
        public bool TryRegister(User user, Event selectedEvent, RegistrationType registrationType)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRegistration(User user, Event selectedEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}