using AutoMapper;
using Microsoft.Owin;
using Owin;
using Rails.Models;

[assembly: OwinStartupAttribute(typeof(Rails.Startup))]
namespace Rails
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Tram, TramViewModel>());
            ConfigureAuth(app);
        }
    }
}
