using System;
using AutoMapper;
using EventEmitter.Storage.POCO;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class AccountManager : IAccountManager
    {
        protected IUserAccountRepository UserAccountRepository;
        protected readonly IMapper Mapper;
        protected readonly ISettingRepository Settings;
        protected const string DefaultUserType = "DEFAULT_USER_TYPE";

        public AccountManager(IUserAccountRepository userAccountRepository, IMapper mapper, ISettingRepository settings)
        {
            UserAccountRepository = userAccountRepository;
            Mapper = mapper;
            Settings = settings;
        }

        public void Register(User user)
        {               
            var mappedUser = Mapper.Map<User, UserAccount>(user);
            mappedUser.UserTypeId = new Guid(Settings.Get(DefaultUserType).Value);
            UserAccountRepository.Insert(mappedUser);
        }

        public User GetInfo(Guid id)
        {
            var storedUser = UserAccountRepository.Get(id);
            return Mapper.Map<UserAccount, User>(storedUser);
        }

        public User GetInfo(string loginProvider, string providerKey)
        {
            var storedUser = UserAccountRepository.Get(loginProvider, providerKey);
            return Mapper.Map<UserAccount, User>(storedUser);

        }
    }
}