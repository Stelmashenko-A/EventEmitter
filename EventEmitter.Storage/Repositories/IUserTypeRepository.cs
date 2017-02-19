using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IUserTypeRepository : IRepository<UserType>
    {
        IEnumerable<UserType> GetAll();
    }
}