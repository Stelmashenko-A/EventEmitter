using System.Collections.Generic;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}
