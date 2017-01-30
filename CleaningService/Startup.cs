using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CleaningService.Startup))]
namespace CleaningService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
