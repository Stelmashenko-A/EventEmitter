using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using EventEmitter.AdminServices.Interfaces;
using EventEmitter.Api.Models.UserType;

namespace EventEmitter.Api.Controllers
{
    [RoutePrefix("api/UserType")]
    public class UserTypeController : CommonController
    {
        protected readonly IUserTypeAdmin UserTypeAdmin;
        protected readonly IClaimAdmin ClaimAdmin;

        public UserTypeController(IUserTypeAdmin userTypeAdmin, IClaimAdmin claimAdmin)
        {
            UserTypeAdmin = userTypeAdmin;
            ClaimAdmin = claimAdmin;
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

        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("Claims")]
        public IEnumerable<Claim> GetClaims()
        {
            var claims = ClaimAdmin.GetAll();
            return claims.Select(x => Mapper.Map<Claim>(x));
        }

        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("GrantedClaims")]
        public IEnumerable<Guid> GrantedClaims(Guid id)
        {
            return UserTypeAdmin.Get(id);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("Claim")]
        public OkResult ClaimAdd(Guid type, Guid claim)
        {
            UserTypeAdmin.AddClaim(type,claim);
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("Claim")]
        public OkResult ClaimRemove(Guid type, Guid claim)
        {
            UserTypeAdmin.RemoveClaim(type,claim);
            return Ok();
        }
    }
}
