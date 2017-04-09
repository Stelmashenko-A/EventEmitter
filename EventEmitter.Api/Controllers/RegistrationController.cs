using System;
using System.Collections.Generic;
using System.Web.Http;
using EventEmitter.Queries;
using EventEmitter.Queries.Registration;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;
using Event = EventEmitter.Queries.Registration.Event;

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
        [AllowAnonymous]
        public IEnumerable<Event> Get([FromUri] UserEventQuery query)
        {
            query.UserId = Account.Id;
            return QueryDispatcher.Ask<UserEventQuery,IEnumerable<Event>>(query);
        }
    }
}
