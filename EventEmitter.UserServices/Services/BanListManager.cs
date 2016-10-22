using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class BanListManager : IBanListManager
    {
        private readonly IStopListRecordRepository _stopListRecordRepository;
        private readonly IMapper _mapper;

        public BanListManager(IMapper mapper, IStopListRecordRepository stopListRecordRepository)
        {
            _stopListRecordRepository = stopListRecordRepository;
            _mapper = mapper;
        }
        public void AddToBanList(Event obj, User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFromBanList(Event obj, User user)
        {
            throw new System.NotImplementedException();
        }

        public bool IsBanned(User user, Event obj)
        {
            return _stopListRecordRepository.Contains(user.Id, obj.Id);
        }
    }
}