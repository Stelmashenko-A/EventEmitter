using System;
using System.Collections.Generic;
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

        public IEnumerable<Claim> Claims()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Claim> Claims(Guid userTypeId)
        {
            throw new NotImplementedException();
        }
    }
}