using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTwitter.Web.Startup))]
namespace MyTwitter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
