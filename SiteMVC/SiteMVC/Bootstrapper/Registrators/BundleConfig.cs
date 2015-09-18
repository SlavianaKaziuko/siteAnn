using System.Web.Optimization;
using SiteMVC.Constants;


namespace SiteMVC.Bootstrapper.Registrators
{
    public static class BundlesRegistrator
    {

        public static void Register(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle(ScriptBundles.JQuery).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(ScriptBundles.Bootstrap).Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle(ScriptBundles.Modernizr).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle(ScriptBundles.Default).Include(
                        "~/Scripts/PhotoSiteScript.js"));

            bundles.Add(new StyleBundle(StyleBundles.Bootstrap).Include(
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle(StyleBundles.Default).Include(
                "~/Content/PhotoSiteStyle.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}