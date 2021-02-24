using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiringTrackingSite.Startup))]
namespace HiringTrackingSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
