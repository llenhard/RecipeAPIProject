using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeAPIProject.Startup))]
namespace RecipeAPIProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
