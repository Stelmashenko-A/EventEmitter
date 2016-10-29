using System;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IUserTypeClaimRepository : IRepository<UserTypeClaim>
    {
        UserTypeClaim Get(Guid userTypeId, POCO.Enums.Claim claim);

    }
}