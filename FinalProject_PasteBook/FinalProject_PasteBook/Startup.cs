using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProject_PasteBook.Startup))]
namespace FinalProject_PasteBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
