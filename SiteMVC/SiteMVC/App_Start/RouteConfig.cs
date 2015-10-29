using System.Web.Mvc;
using System.Web.Routing;

namespace SiteMVC.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Portfolio_Default",
                "Portfolio/{action}/{id}",
                new {controller = "Portfolio", action = "Portfolio", id = UrlParameter.Optional});
            routes.MapRoute(
                "Responses_Default",
                "Responses/{action}/{id}",
                new { controller = "Responses", action = "Responses", id = UrlParameter.Optional });
            routes.MapRoute(
                "Services_Default",
                "Services/{action}/{id}",
                new {controller = "Services", action = "Services", id = UrlParameter.Optional});
            routes.MapRoute(
                "News_Default",
                "News/{action}/{id}",
                new { controller = "News", action = "News", id = UrlParameter.Optional });
            routes.MapRoute(
                "Contacts_Default",
                "Contacts/{action}/{id}",
                new { controller = "Contacts", action = "Contacts", id = UrlParameter.Optional });
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}