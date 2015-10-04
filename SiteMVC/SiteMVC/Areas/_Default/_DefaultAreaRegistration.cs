using System.Web.Mvc;

namespace SiteMVC.Areas._Default
{
    public class _DefaultAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "_Default";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Services_Default",
                "_Default/Services/{action}/{id}",
                new { controller = "Services", action = "Services", id = UrlParameter.Optional });
            context.MapRoute(
                "Contacts_Default",
                "_Default/Contacts/{action}/{id}",
                new { controller = "Contacts", action = "Contacts", id = UrlParameter.Optional });
            context.MapRoute(
                "Responses_Default",
                "_Default/Responses/{action}/{id}",
                new { controller = "Responses", action = "Responses", id = UrlParameter.Optional });
            context.MapRoute(
                "Portfolio_Default",
                "_Default/Portfolio/{action}/{id}",
                new { controller = "Portfolio", action = "Portfolio", id = UrlParameter.Optional });
            context.MapRoute(
                "_Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Home", id = UrlParameter.Optional });

        }
    }
}
