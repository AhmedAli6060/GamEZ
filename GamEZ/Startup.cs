using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamEZ.Startup))]
namespace GamEZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
