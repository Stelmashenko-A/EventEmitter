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
        private readonly IRegistrator _registrator;

        public RegistrationController(IRegistrator registrator)
        {
            _registrator = registrator;
        }

        [Route("Register")]
        public IHttpActionResult Register(Guid id)
        {
            if (_registrator.TryRegister(Account, id, RegistrationType.Go))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("Interested")]
        public IHttpActionResult Interested(Guid id)
        {
            if (_registrator.TryRegister(Account, id, RegistrationType.Interested))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("Dismiss")]
        public IHttpActionResult Dismiss(Guid id)
        {
            if (_registrator.TryRemoveRegistration(Account, id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
