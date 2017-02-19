using System.Collections.Generic;
using System.Linq;
using EventEmitter.AdminServices;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Api.Models.UserType;

namespace EventEmitter.Api.Controllers
{
    public class UserTypeController : CommonController
    {
        protected readonly IUserTypeAdmin UserTypeAdmin;

        public UserTypeController(IUserTypeAdmin userTypeAdmin)
        {
            UserTypeAdmin = userTypeAdmin;
        }

        public IEnumerable<UserType> Get()
        {
            var userTypes = UserTypeAdmin.GetAll();
            return userTypes.Select(x => Mapper.Map<UserType>(x));
        }
    }
}
