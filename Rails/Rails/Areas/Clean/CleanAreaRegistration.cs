using System.Web.Mvc;

namespace Rails.Areas.Clean
{
    public class CleanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clean";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clean_default",
                "Clean/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "Rails.Areas.Clean.Controllers" }
            );
        }
    }
}