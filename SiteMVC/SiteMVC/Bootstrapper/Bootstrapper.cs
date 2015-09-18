using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SiteMVC.Bootstrapper.Registrators;

namespace SiteMVC.Bootstrapper
{
    public class Bootstrapper : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundlesRegistrator.Register(BundleTable.Bundles);
        }
    }
}