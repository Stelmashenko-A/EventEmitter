using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Api.Models.User;
using EventEmitter.Queries.User;
using User = EventEmitter.Api.Models.User.User;

namespace EventEmitter.Api.Controllers
{
    [RoutePrefix("api/User")]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("part")]
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<Queries.User.User> GetByPartOfName([FromUri] UserQuery query)
        {
            query.Count = 10;
            return QueryBus.Ask<UserQuery, IEnumerable<Queries.User.User>>(query);
        } 
        
    }
}
