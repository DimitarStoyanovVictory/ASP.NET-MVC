using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CachingWebApi.Startup))]
namespace CachingWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
