using System;
using System.Collections.Generic;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IClaimManager
    {
        bool HasClaim(User user, Claim claim);
        IEnumerable<Claim> Claims(User user);
        IEnumerable<Claim> Claims();
        IEnumerable<Claim> Claims(Guid userTypeId);
    }

    class ClaimManager : IClaimManager
    {
        private IUserTypeClaimRepository _userTypeClaimRepository;
        private IMapper _mapper;
        public ClaimManager(IUserTypeClaimRepository userTypeClaimRepository, IMapper mapper)
        {
            _userTypeClaimRepository = userTypeClaimRepository;
            _mapper = mapper;
        }

        public bool HasClaim(User user, Claim claim)
        {
            var storedClaim = _mapper.Map<Claim, Storage.POCO.Enums.Claim>(claim);
            return _userTypeClaimRepository.Get(user.UserTypeId, storedClaim) != null;
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
