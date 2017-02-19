using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Api.Models.UserType;

namespace EventEmitter.Api.Controllers
{
    [RoutePrefix("api/UserType")]
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
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        [HttpGet]

        [Route("Stat")]
        public IEnumerable<UserType> Stat()
        {
            var userTypes = UserTypeAdmin.GetAllWithStat();
            return userTypes.Select(x => Mapper.Map<UserType>(x));
        }
    }
}
