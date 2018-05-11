using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewAnimalSearch.Startup))]
namespace NewAnimalSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
