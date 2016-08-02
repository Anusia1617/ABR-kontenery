using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KonteneryMVC.Startup))]
namespace KonteneryMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
