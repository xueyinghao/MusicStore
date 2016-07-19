using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Music.Startup))]
namespace Music
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
