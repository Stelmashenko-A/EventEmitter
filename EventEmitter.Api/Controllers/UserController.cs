using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.AdminServices;

namespace EventEmitter.Api.Controllers
{
    public class UserController : CommonController
    {
        protected readonly IUserAdmin UserAdmin;

        public UserController(IUserAdmin userAdmin)
        {
            UserAdmin = userAdmin;
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        /*public string Get(int id)
        {
            return "value";
        }*/

        // GET: api/User/5

        public IEnumerable<Models.User> Get(int page)
        {
            var result = UserAdmin.GetPage(page);
            return result.Select(x => Mapper.Map<Models.User>(x));
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
