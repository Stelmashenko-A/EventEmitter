using System;
using System.Collections.Generic;
using System.Web.Http;
using EventEmitter.UserServices;

namespace EventEmitter.Api.Controllers
{
    public class MessageController : CommonController
    {
        private IMessager _messager;

        public MessageController(IMessager messager)
        {
            _messager = messager;
        }

        // GET: api/Message
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }
        public class MessageModel
        {
            public string text { get; set; }
            public Guid eventId { get; set; }
        }
        // POST: api/Message
        public IHttpActionResult Post([FromBody] MessageModel data)
        {
            _messager.Send(data.eventId,Account,data.text);
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
