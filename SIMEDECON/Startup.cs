using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIMEDECON.Startup))]
namespace SIMEDECON
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
