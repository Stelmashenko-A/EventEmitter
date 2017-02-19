using System;
using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IClaimRepository : IRepository<Claim>
    {
        IEnumerable<Claim> GetAll();

        IEnumerable<Claim> GetForUserType(Guid userTypeId);

        POCO.Enums.Claim GetMapped(Guid claimId);
    }
}