using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    class ContactManager : IContactManager
    {
        public void Share(Contact contact, User @from, User to)
        {
            throw new System.NotImplementedException();
        }

        public void Share(Contact contact, User @from, User to, Event obj)
        {
            throw new System.NotImplementedException();
        }
    }
}