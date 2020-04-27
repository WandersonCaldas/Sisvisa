using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SISVISA.UI.Web.Startup))]
namespace SISVISA.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
