using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_EntityFW.Startup))]
namespace MVC_EntityFW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
