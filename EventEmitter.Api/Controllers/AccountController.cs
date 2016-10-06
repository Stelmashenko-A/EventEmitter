using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using CredentialStorage;
using EventEmitter.Api.Models;
using EventEmitter.Api.Results;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace EventEmitter.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

        public AccountController()
        {
        }

        public AccountController(ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            AccessTokenFormat = accessTokenFormat;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

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
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
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
            var uar = new UserAccountRepository();
            var user = uar.Get(externalLogin.LoginProvider, externalLogin.ProviderKey);

            var hasRegistered = user != null;

            if (!hasRegistered)
            {
                user = new UserAccount()
                {
                    Name = externalLogin.UserName,
                    LoginProvider = externalLogin.LoginProvider,
                    LoginProviderKey = externalLogin.ProviderKey,
                    Base64Secret = "eigiure",
                    ApplicationId = new Guid("78F73412-15FC-4580-A351-07DA74EAE1A6")
                };
                var userAccountRepository = new UserAccountRepository();
                userAccountRepository.Insert(user);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identetyBuilder = new IdentetyBuilder();
            var oAuthIdentity = identetyBuilder.Build(user, OAuthDefaults.AuthenticationType);
            var cookieIdentity = identetyBuilder.Build(user, CookieAuthenticationDefaults.AuthenticationType);
            var propertyBuilder = new PropertyBuilder();
            var properties = propertyBuilder.Build(user);
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
                    State = state
                };
                login.Url = Url.Route("ExternalLogin", new
                {
                    provider = description.AuthenticationType,
                    response_type = "token",
                    client_id = Startup.PublicClientId,
                    redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                    state = state
                });
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

    public class IdentetyBuilder
    {
        public ClaimsIdentity Build(UserAccount user, string authenticationType)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("Id", user.UserAccountId.ToString()),
                new Claim("ApplicationId", user.ApplicationId.ToString())
            };
            return new ClaimsIdentity(claims, authenticationType);
        }
    }

    public class PropertyBuilder
    {
        public AuthenticationProperties Build(UserAccount user)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", user.Name }
            };
            return new AuthenticationProperties(data);
        }
    }
}
