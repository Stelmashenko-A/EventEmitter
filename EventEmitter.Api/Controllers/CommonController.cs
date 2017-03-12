using System;
using System.Web.Http;
using AutoMapper;
using EventEmitter.Core.Command;
using EventEmitter.Core.Query;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace EventEmitter.Api.Controllers
{
    [Authorize]
    public class CommonController : ApiController
    {
        private User _account;

        [Inject]
        public IAccountManager AccountManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IQueryBus QueryBus { get; set; }

        [Inject]
        public ICommandBus CommandBus { get; set; }

        public User Account
        {
            get
            {
                if (_account != null) return _account;

                var strGuid = User.Identity.GetUserId();
                if (strGuid == null) return _account;

                var guid = new Guid(strGuid);
                _account = AccountManager.GetInfo(guid);

                return _account;
            }
        }
    }
}