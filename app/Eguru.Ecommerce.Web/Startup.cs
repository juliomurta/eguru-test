using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eguru.Ecommerce.Web.Startup))]
namespace Eguru.Ecommerce.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
