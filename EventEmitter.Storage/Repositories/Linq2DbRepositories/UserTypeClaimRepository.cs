using System;
using System.Linq;
using EventEmitter.Storage.POCO;
using Claim = EventEmitter.Storage.POCO.Enums.Claim;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class UserTypeClaimRepository : Repository<UserTypeClaim>, IUserTypeClaimRepository
    {
        public UserTypeClaim Get(Guid userTypeId, Claim claim)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.UserTypeClaims
                            where item.UserTypeId == userTypeId
                            && item.Claim == claim
                            select item;
                return query.FirstOrDefault();
            }
        }
    }
}