using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1ClickMelodyApplication.Startup))]
namespace _1ClickMelodyApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
