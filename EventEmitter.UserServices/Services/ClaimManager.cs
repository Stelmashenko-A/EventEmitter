using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class ClaimManager : IClaimManager
    {
        protected IUserTypeClaimRepository UserTypeClaimRepository;
        protected IMapper Mapper;

        public ClaimManager(IUserTypeClaimRepository userTypeClaimRepository, IMapper mapper)
        {
            UserTypeClaimRepository = userTypeClaimRepository;
            Mapper = mapper;
        }

        public bool HasClaim(User user, Claim claim)
        {
            var storedClaim = Mapper.Map<Claim, Storage.POCO.Enums.Claim>(claim);
            return UserTypeClaimRepository.Get(user.UserTypeId, storedClaim) != null;
        }

        public IEnumerable<Claim> Claims(User user)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, List<Claim>> Claims()
        {
            var claims = UserTypeClaimRepository.GetAll();
            return claims.ToDictionary(claim => claim.Key, claim => claim.Value
            .Select(claim1 => Mapper.Map<Storage.POCO.Enums.Claim, Claim>(claim1)).ToList());
        }

        public IEnumerable<Claim> Claims(Guid userTypeId)
        {
            throw new NotImplementedException();
        }
    }
}