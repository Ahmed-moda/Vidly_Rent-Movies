using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_2.Startup))]
namespace Vidly_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
