using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParrentPortalWeb.Startup))]
namespace ParrentPortalWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
