using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.AdminServices.Models;
using EventEmitter.Storage.Repositories;

namespace EventEmitter.AdminServices.Implementation
{
    public class ClaimAdmin : IClaimAdmin
    {
        protected readonly IClaimRepository ClaimRepository;
        protected readonly IMapper Mapper;

        public ClaimAdmin(IClaimRepository claimRepository, IMapper mapper)
        {
            ClaimRepository = claimRepository;
            Mapper = mapper;
        }

        public IEnumerable<Claim> GetAll()
        {
            var storedClaims = ClaimRepository.GetAll();
            return storedClaims.Select(x => Mapper.Map<Claim>(x));
        }
    }
}