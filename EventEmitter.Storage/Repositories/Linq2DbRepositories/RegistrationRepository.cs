using System;
using System.Linq;
using EventEmitter.Storage.POCO;
using RegistrationType = EventEmitter.Storage.POCO.Enums.RegistrationType;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class RegistrationRepository : Repository<Registration>, IRegistrationRepository
    {
        public bool Contains(Guid userId, Guid eventId, RegistrationType type)
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.Registrations.Any(item => item.UserAccountId == userId
                                                         && item.EventId == eventId
                                                         && item.Type == type);
            }
        }

        public bool Get(Guid userId, Guid eventId)
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.Registrations.Any(item => item.UserAccountId == userId
                                                         && item.EventId == eventId);
            }
        }
    }
}