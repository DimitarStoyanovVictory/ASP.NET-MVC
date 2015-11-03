using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tiwtter.Web.Startup))]
namespace Tiwtter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
