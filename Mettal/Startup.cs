using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mettal.Startup))]
namespace Mettal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
