using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;
using LinqToDB.Common;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class ClaimRepository : Repository<Claim>, IClaimRepository
    {
        public IEnumerable<Claim> GetAll()
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.Claims.ToList();
            }
        }

        public IEnumerable<Guid> GetForUserType(Guid userTypeId)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from typeClaim in db.UserTypeClaims
                    where typeClaim.UserTypeId == userTypeId
                    select typeClaim.Claim;

                return query.ToList().Select(x => new Guid(ConvertTo<string>.From(x))).ToList();
            }
        }

        public POCO.Enums.Claim GetMapped(Guid claimId)
        {
            var storedClaim = Get(claimId);
            return ConvertTo<POCO.Enums.Claim>.From(storedClaim);
        }
    }
}