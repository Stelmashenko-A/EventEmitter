using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.Commands.SendMessage;
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

        public IEnumerable<string> Get(Guid id)
        {
            return Messager.GetAll(id).Select(item => item.Text);
        }

        public IHttpActionResult Post([FromBody] SendMessageCommand command)
        {
            command.Author = Account.Id;
            CommandDispatcher.Execute(command);
            return Ok();
        }
    }
}
