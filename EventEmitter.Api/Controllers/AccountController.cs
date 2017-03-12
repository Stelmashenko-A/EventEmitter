using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using EventEmitter.Api.Authentification;
using EventEmitter.Api.Models;
using EventEmitter.Api.Results;
using EventEmitter.UserServices;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using User = EventEmitter.UserServices.Models.User;

namespace EventEmitter.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        protected readonly IAccountManager AccountManager;
        protected readonly IPropertyBuilder PropertyBuilder;
        protected readonly IIdentetyBuilder IdentetyBuilder;

        public AccountController(IAccountManager accountManager,
            IPropertyBuilder propertyBuilder,
            IIdentetyBuilder identetyBuilder)
        {
            AccountManager = accountManager;
            PropertyBuilder = propertyBuilder;
            IdentetyBuilder = identetyBuilder;
        }

        public AccountController(ISecureDataFormat<AuthenticationTicket> accessTokenFormat, IAccountManager accountManager, IPropertyBuilder propertyBuilder, IIdentetyBuilder identetyBuilder)
        {
            AccessTokenFormat = accessTokenFormat;
            AccountManager = accountManager;
            PropertyBuilder = propertyBuilder;
            IdentetyBuilder = identetyBuilder;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            var externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Email = User.Identity.GetUserName(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin?.LoginProvider
            };
        }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // GET api/Account/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public IHttpActionResult GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            var externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }


            var user = AccountManager.GetInfo(externalLogin.LoginProvider, externalLogin.ProviderKey);

            var hasRegistered = user != null;

            if (!hasRegistered)
            {
                user = new User
                {
                    Name = externalLogin.UserName,
                    LoginProvider = externalLogin.LoginProvider,
                    LoginProviderKey = externalLogin.ProviderKey,
                    Base64Secret = "eigiure",
                };

                AccountManager.Register(user);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var oAuthIdentity = IdentetyBuilder.Build(user, OAuthDefaults.AuthenticationType);
            var cookieIdentity = IdentetyBuilder.Build(user, CookieAuthenticationDefaults.AuthenticationType);
            var properties = PropertyBuilder.Build(user);
            Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);

            return Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            var logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (var description in descriptions)
            {
                var login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    State = state,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state
                    })
                };
                logins.Add(login);
            }

            return logins;
        }

       

       

        #region Helpers

        private IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;

        private class ExternalLoginData
        {
            public string LoginProvider { get; private set; }
            public string ProviderKey { get; private set; }
            public string UserName { get; private set; }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                var providerKeyClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(providerKeyClaim?.Issuer) || string.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static readonly RandomNumberGenerator Random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", nameof(strengthInBits));
                }

                var strengthInBytes = strengthInBits / bitsPerByte;

                var data = new byte[strengthInBytes];
                
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
