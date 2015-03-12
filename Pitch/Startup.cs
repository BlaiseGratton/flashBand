using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pitch.Startup))]
namespace Pitch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
