using Microsoft.Owin;
using Owin;
using ParPorWebApp;

[assembly: OwinStartup(typeof(Startup))]

namespace ParPorWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}