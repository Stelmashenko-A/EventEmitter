using System;
using AutoMapper;
using EventEmitter.Storage.POCO;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IAccountManager
    {
        void Register(User user);
        User GetInfo(Guid id);
        User GetInfo(string loginProvider, string providerKey);
    }

    public class AccountManager : IAccountManager
    {
        protected IUserAccountRepository UserAccountRepository;
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settings;

        public AccountManager(IUserAccountRepository userAccountRepository, IMapper mapper, ISettingRepository settings)
        {
            UserAccountRepository = userAccountRepository;
            _mapper = mapper;
            _settings = settings;
        }

        public void Register(User user)
        {               
            var mappedUser = _mapper.Map<User, UserAccount>(user);
            mappedUser.UserTypeId = new Guid(_settings.Get("DEFAULT_USER_TYPE").Value);
            UserAccountRepository.Insert(mappedUser);
        }

        public User GetInfo(Guid id)
        {
            var storedUser = UserAccountRepository.Get(id);
            return _mapper.Map<UserAccount, User>(storedUser);
        }

        public User GetInfo(string loginProvider, string providerKey)
        {
            var storedUser = UserAccountRepository.Get(loginProvider, providerKey);
            return _mapper.Map<UserAccount, User>(storedUser);

        }
    }
}
