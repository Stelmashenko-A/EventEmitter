using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.AdminServices.Models;
using EventEmitter.Storage.Repositories;

namespace EventEmitter.AdminServices.Implementation
{
    public class UserTypeAdmin : IUserTypeAdmin
    {
        protected readonly IUserTypeRepository UserTypeRepository;
        protected readonly IMapper Mapper;

        public UserTypeAdmin(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            UserTypeRepository = userTypeRepository;
            Mapper = mapper;
        }

        public IEnumerable<UserType> GetAll()
        {
            var storedTypes = UserTypeRepository.GetAll();
            return storedTypes.Select(x => Mapper.Map<UserType>(x));
        }
    }
}