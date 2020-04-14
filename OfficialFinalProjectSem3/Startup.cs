using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OfficialFinalProjectSem3.Startup))]
namespace OfficialFinalProjectSem3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
