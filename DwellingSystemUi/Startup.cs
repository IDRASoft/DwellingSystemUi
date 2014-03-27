using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DwellingSystemUi.Startup))]
namespace DwellingSystemUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
