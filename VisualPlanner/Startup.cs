using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VisualPlanner.Startup))]
namespace VisualPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
