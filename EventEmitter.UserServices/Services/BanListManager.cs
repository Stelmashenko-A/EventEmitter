using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class BanListManager : IBanListManager
    {
        protected readonly IStopListRecordRepository StopListRecordRepository;
        protected readonly IMapper Mapper;

        public BanListManager(IMapper mapper, IStopListRecordRepository stopListRecordRepository)
        {
            StopListRecordRepository = stopListRecordRepository;
            Mapper = mapper;
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
            return StopListRecordRepository.Contains(user.Id, obj.Id);
        }
    }
}