using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Storage.POCO;
using EventEmitter.Storage.Repositories;
using Claim = EventEmitter.AdminServices.Models.Claim;
using UserType = EventEmitter.AdminServices.Models.UserType;

namespace EventEmitter.AdminServices.Implementation
{
    public class UserTypeAdmin : IUserTypeAdmin
    {
        protected readonly IUserTypeRepository UserTypeRepository;
        protected readonly IClaimRepository ClaimRepository;
        protected readonly IUserTypeClaimRepository UserTypeClaimRepository;
        protected readonly IMapper Mapper;

        public UserTypeAdmin(IUserTypeRepository userTypeRepository,
            IMapper mapper,
            IClaimRepository claimRepository, IUserTypeClaimRepository userTypeClaimRepository)
        {
            UserTypeRepository = userTypeRepository;
            Mapper = mapper;
            ClaimRepository = claimRepository;
            UserTypeClaimRepository = userTypeClaimRepository;
        }

        public IEnumerable<UserType> GetAll()
        {
            var storedTypes = UserTypeRepository.GetAll();
            return storedTypes.Select(x => Mapper.Map<UserType>(x));
        }

        public IEnumerable<UserType> GetAllWithStat()
        {
            var storedTypes = UserTypeRepository.GetAllModels();
            return storedTypes.Select(x => Mapper.Map<UserType>(x));
        }

        public UserType AddUserType(string name)
        {
            if(UserTypeRepository.Contains(x => x.Name==name)) throw new ArgumentException("Name exist");

            var newUserType = new Storage.POCO.UserType {Name = name, Id = Guid.NewGuid()};
            UserTypeRepository.Insert(newUserType);

            return Mapper.Map<UserType>(newUserType);
        }

        public IEnumerable<Claim> Get()
        {
            var storedClaims = ClaimRepository.GetAll();
            return storedClaims.Select(x => Mapper.Map<Claim>(x));
        }

        public IEnumerable<Guid> Get(Guid userTypeId)
        {
            return ClaimRepository.GetForUserType(userTypeId);
        }

        public void RemoveClaim(Guid userTypeId, Guid claimId)
        {
            var claim = UserTypeClaimRepository.Get(userTypeId, claimId);
            if (claim != null)
            {
                UserTypeClaimRepository.Delete(claim);
            }
        }

        public void AddClaim(Guid userTypeId, Guid claimId)
        {
            var claim = ClaimRepository.GetMapped(claimId);
            UserTypeClaimRepository.Insert(new UserTypeClaim { Claim = claim, UserTypeId = userTypeId });
        }
    }
}