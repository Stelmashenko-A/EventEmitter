using System;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        bool Contains(Guid userId, Guid eventId, POCO.Enums.RegistrationType type);
    }
}