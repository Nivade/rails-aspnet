using System.Web.Mvc;

namespace Rails.Areas.Remise
{
    public class RemiseAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Remise";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Remise_default",
                "Remise/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new []{"Rails.Areas.Remise.Controllers"}
            );
        }
    }
}