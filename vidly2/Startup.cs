using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vidly2.Startup))]
namespace vidly2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
