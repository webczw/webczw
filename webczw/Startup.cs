using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webczw.Startup))]
namespace webczw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
