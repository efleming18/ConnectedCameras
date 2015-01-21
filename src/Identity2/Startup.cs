using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConnectedCamerasWeb.Startup))]
namespace ConnectedCamerasWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
