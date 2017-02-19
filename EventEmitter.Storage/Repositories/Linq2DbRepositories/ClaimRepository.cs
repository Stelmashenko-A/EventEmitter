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

        public IEnumerable<Claim> GetForUserType(Guid userTypeId)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from claim in db.Claims
                    join userTypeClaim in db.UserTypeClaims on claim.Id equals userTypeClaim.UserTypeId
                    where userTypeClaim.UserTypeId == userTypeId
                    select claim;

                return query.ToList();
            }
        }

        public POCO.Enums.Claim GetMapped(Guid claimId)
        {
            var storedClaim = Get(claimId);
            return ConvertTo<POCO.Enums.Claim>.From(storedClaim);
        }
    }
}