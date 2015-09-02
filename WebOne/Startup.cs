using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebOne.Startup))]
namespace WebOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
