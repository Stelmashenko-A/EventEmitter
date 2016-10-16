using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IBanListManager
    {
        void AddToBanList(Event obj, User user);
        void RemoveFromBanList(Event obj, User user);
        bool IsBanned(User user, Event obj);
    }
}