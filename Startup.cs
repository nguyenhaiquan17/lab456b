using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BS.Startup))]
namespace BS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
