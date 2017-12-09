using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KR.Web_.Startup))]
namespace KR.Web_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
