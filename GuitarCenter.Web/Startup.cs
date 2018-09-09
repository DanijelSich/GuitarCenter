using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuitarCenter.Web.Startup))]
namespace GuitarCenter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
