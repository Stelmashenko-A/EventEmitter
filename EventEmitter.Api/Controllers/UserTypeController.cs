using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.AdminServices;
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

        // GET: api/UserType/5
        [AllowAnonymous]
        public IEnumerable<UserType> Get()
        {
            var userTypes = UserTypeAdmin.GetAll();
            return userTypes.Select(x => Mapper.Map<UserType>(x));
        }

        // POST: api/UserType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserType/5
        public void Delete(int id)
        {
        }
    }
}
