using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShopperStock.WebUI.Startup))]
namespace MyShopperStock.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
