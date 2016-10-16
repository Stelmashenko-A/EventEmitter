using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface IContactManager
    {
        void Share(Contact contact, User from, User to);
        void Share(Contact contact, User from, User to, Event obj);
    }
}