using System.Collections.Generic;
using EventEmitter.AdminServices.Models;

namespace EventEmitter.AdminServices.Interfaces
{
    public interface IClaimAdmin
    {
        IEnumerable<Claim> GetAll();
    }
}