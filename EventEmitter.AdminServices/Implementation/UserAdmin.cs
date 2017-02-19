using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.AdminServices.Models;
using EventEmitter.Storage.Repositories;

namespace EventEmitter.AdminServices.Implementation
{
    public class UserAdmin : IUserAdmin
    {
        protected readonly IUserAccountRepository UserAccountRepository;
        protected readonly IMapper Mapper;

        public UserAdmin(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            UserAccountRepository = userAccountRepository;
            Mapper = mapper;
        }

        public void UpdateUserType(Guid userId, Guid newUserType)
        {
            var user = UserAccountRepository.Get(userId);
            if (user == null) return;
            user.UserTypeId = newUserType;
            UserAccountRepository.Update(user);
        }

        public IEnumerable<User> GetPage(int page)
        {
            var result = UserAccountRepository.Get(page, 20);
            return result.Select(x => Mapper.Map<Storage.Models.User, User>(x));
        }
    }
}