using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaiTap_Buoi3.Startup))]
namespace BaiTap_Buoi3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
