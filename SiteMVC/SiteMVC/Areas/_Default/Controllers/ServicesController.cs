using System.Web.Mvc;

namespace SiteMVC.Areas._Default.Controllers
{
    public class ServicesController : Controller
    {
        //
        // GET: /_Default/Services/

        public ActionResult Services()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Services");
            }

            ViewBag.Layout = "~/Areas/_Default/Views/_Layout.cshtml";
            return View();
        }

    }
}
