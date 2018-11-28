using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmallJobsApp_BlueBadge.Startup))]
namespace SmallJobsApp_BlueBadge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
