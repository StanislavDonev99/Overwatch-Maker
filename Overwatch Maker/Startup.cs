using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Overwatch_Maker.Startup))]
namespace Overwatch_Maker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
