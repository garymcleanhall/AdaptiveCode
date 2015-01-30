using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sermo.UI.Startup))]
namespace Sermo.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
