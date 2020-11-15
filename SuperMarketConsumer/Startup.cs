using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperMarketConsumer.Startup))]
namespace SuperMarketConsumer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
