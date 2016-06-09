using AutoMapper;
using Microsoft.Owin;
using Owin;
using Rails.Models;
using Rails.Models.View;

[assembly: OwinStartupAttribute(typeof(Rails.Startup))]
namespace Rails
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
