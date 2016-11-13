using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;
using Ninject;

namespace EventEmitter.Api.Controllers
{
    [Authorize]
    public class CommonController : ApiController
    {
        private User _account;

        [Inject]
        public IAccountManager AccountManager { get; set; }

        public User Account
        {
            get
            {
                if (_account != null) return _account;

                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                if (identity == null) return _account;

                var strGuid = identity.Claims.Where(item => item.Type == "Id").Select(item => item.Value).FirstOrDefault();
                if (strGuid == null) return _account;

                var guid = new Guid(strGuid);
                _account = AccountManager.GetInfo(guid);

                return _account;
            }
        }
    }
}