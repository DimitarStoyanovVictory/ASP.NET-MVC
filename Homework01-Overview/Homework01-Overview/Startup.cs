using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework01_Overview.Startup))]
namespace Homework01_Overview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
