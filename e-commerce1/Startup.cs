using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(e_commerce1.Startup))]
namespace e_commerce1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
