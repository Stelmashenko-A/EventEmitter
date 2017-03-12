using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Api.Models.User;

namespace EventEmitter.Api.Controllers
{
    public class UserController : CommonController
    {
        protected readonly IUserAdmin UserAdmin;

        public UserController(IUserAdmin userAdmin)
        {
            UserAdmin = userAdmin;
        }

        public IEnumerable<User> Get(int page)
        {
            var result = UserAdmin.GetPage(page);
            return result.Select(x => Mapper.Map<User>(x));
        }

        public IHttpActionResult ChangeUserType([FromBody]ChangeUserTypeRequest request)
        {
            UserAdmin.UpdateUserType(request.UserId,request.UserTypeId);
            return Ok();
        }
        
    }
}
