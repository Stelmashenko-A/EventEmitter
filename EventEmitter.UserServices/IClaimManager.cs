using System;
using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IClaimManager
    {
        bool HasClaim(User user, Claim claim);
        IEnumerable<Claim> Claims(User user);
        Dictionary<Guid, List<Claim>> Claims();
        IEnumerable<Claim> Claims(Guid userTypeId);
    }
}
