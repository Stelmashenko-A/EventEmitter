using System;

namespace CredentialStorage
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T id);
        T Get(Guid id);
    }
}