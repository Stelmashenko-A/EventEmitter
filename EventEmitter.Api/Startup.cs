using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EventEmitter.Api.Startup))]

namespace EventEmitter.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
