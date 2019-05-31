using Microsoft.Owin;
using Owin;
using Possible.MessageWeb;

[assembly: OwinStartup(typeof(Startup))]
namespace Possible.MessageWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
