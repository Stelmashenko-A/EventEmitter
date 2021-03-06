using System;
using System.Collections.Generic;
using EventEmitter.AdminServices.Models;

namespace EventEmitter.AdminServices.Interfaces
{
    public interface IUserTypeAdmin
    {
        IEnumerable<UserType> GetAll();
        IEnumerable<UserType> GetAllWithStat();
        IEnumerable<Claim> Get();
        IEnumerable<Guid> Get(Guid userTypeId);
        UserType AddUserType(string name);
        void RemoveClaim(Guid userTypeId, Guid claimId);
        void AddClaim(Guid userTypeId, Guid claimId);
    }
}