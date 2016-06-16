using System.Web.Mvc;

namespace Rails.Areas.Bestuurder
{
    public class BestuurderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Bestuurder";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bestuurder_default",
                "Bestuurder/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "Rails.Areas.Bestuurder.Controllers" }
            );
        }
    }
}