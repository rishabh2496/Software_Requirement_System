using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Software_Requirement_System.Startup))]
namespace Software_Requirement_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
