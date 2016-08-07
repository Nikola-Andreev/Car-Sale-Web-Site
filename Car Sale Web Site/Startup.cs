using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Car_Sale_Web_Site.Startup))]
namespace Car_Sale_Web_Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
