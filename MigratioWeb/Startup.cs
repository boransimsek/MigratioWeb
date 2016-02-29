using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MigratioWeb.Startup))]
namespace MigratioWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
