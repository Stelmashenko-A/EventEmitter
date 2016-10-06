using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AuthorizationServer.Api.Startup))]

namespace AuthorizationServer.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
