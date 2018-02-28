using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Client.Startup))]
namespace MVC_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
