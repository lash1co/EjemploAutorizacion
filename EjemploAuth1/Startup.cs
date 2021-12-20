using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EjemploAuth1.Startup))]
namespace EjemploAuth1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
