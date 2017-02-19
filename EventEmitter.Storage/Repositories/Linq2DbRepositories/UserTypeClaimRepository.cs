using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;
using LinqToDB.Common;
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

        public UserTypeClaim Get(Guid userTypeId, Guid claimId)
        {
            var claim = ConvertTo<Claim>.From(claimId);
            return Get(userTypeId, claim);
        }

        public Dictionary<Guid, List<Claim>> GetAll()
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.UserTypeClaims
                            select item;

                var result = new Dictionary<Guid, List<Claim>>();

                foreach (var x in query.OrderBy(item => item.UserTypeId).GroupBy(item => item.UserTypeId))
                {
                    result.Add(x.Key, x.Select(item => item.Claim).ToList());
                }
                return result;
            }
        }
    }
}