using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.AdminServices.Models;
using EventEmitter.Storage.Repositories;

namespace EventEmitter.AdminServices
{
    public interface IUserAdmin
    {
        void UpdateUserType(Guid userId, Guid newUserType);
        IEnumerable<User> GetPage(int page);
    }

    class UserAdmin : IUserAdmin
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

    public interface IUserTypeAdmin
    {
        IEnumerable<UserType> GetAll();
    }

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
