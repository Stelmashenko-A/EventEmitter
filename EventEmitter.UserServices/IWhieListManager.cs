using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IWhieListManager
    {
        void AddToWhiteList(Event obj, User user);
        void RemoveFromWhiteList(Event obj, User user);
        bool IsInWhiteList(User user, Event obj);
    }
}