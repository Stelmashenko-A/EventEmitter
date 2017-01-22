using System;
using System.Web.Http;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Registration")]
    public class RegistrationController : CommonController
    {
        protected readonly IRegistrator Registrator;

        public RegistrationController(IRegistrator registrator)
        {
            Registrator = registrator;
        }

        [Route("Register")]
        public IHttpActionResult Register(Guid id)
        {
            if (Registrator.TryRegister(Account, id, RegistrationType.Go))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("Interested")]
        public IHttpActionResult Interested(Guid id)
        {
            if (Registrator.TryRegister(Account, id, RegistrationType.Interested))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("Dismiss")]
        public IHttpActionResult Dismiss(Guid id)
        {
            if (Registrator.TryRemoveRegistration(Account, id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
