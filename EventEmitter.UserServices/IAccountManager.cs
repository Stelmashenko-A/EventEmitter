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

        public AccountManager(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            UserAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public void Register(User user)
        {
            var mappedUser = _mapper.Map<User, UserAccount>(user);
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
