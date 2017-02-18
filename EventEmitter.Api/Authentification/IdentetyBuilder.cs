using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;
using Claim = System.Security.Claims.Claim;

namespace EventEmitter.Api.Authentification
{
    public class IdentetyBuilder : IIdentetyBuilder
    {
        protected readonly IClaimManager ClaimManager;

        public IdentetyBuilder(IClaimManager claimManager)
        {
            ClaimManager = claimManager;
        }

        public ClaimsIdentity Build(User user, string authenticationType)
        {
            var storedClaims = ClaimManager.Claims();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            claims.AddRange(storedClaims[user.UserTypeId]
                .Select(storedClaim => new Claim(ClaimTypes.Role, storedClaim.ToString("G"))));
            return new ClaimsIdentity(claims, authenticationType);
        }
    }
}