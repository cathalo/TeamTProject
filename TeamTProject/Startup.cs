using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamTProject.Startup))]
namespace TeamTProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
