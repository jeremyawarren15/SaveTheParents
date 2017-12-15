using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaveTheParents.Web.Startup))]
namespace SaveTheParents.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
