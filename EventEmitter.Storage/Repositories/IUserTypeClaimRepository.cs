using System;
using System.Collections.Generic;
using EventEmitter.Storage.POCO;
using Claim = EventEmitter.Storage.POCO.Enums.Claim;

namespace EventEmitter.Storage.Repositories
{
    public interface IUserTypeClaimRepository : IRepository<UserTypeClaim>
    {
        UserTypeClaim Get(Guid userTypeId, Claim claim);
        Dictionary<Guid, List<Claim>> GetAll();

    }
}