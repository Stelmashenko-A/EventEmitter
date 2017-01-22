using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.Api.Models.Message;
using EventEmitter.UserServices;

namespace EventEmitter.Api.Controllers
{
    public class MessageController : CommonController
    {
        protected IMessager Messager;

        public MessageController(IMessager messager)
        {
            Messager = messager;
        }

        // GET: api/Message/5
        public IEnumerable<string> Get(Guid id)
        {
            return Messager.GetAll(id).Select(item => item.Text);
        }

        // POST: api/Message
        public IHttpActionResult Post([FromBody] MessageModel data)
        {
            Messager.Send(data.eventId,Account,data.text);
            return Ok();
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
