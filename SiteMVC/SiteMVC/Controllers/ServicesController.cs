using System.Web.Mvc;

namespace SiteMVC.Controllers
{
    public class ServicesController : Controller
    {
        //
        // GET: /Services/

        public ActionResult Services()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Services");
            }

            ViewBag.Layout = "~/Views/_Layout.cshtml";
            return View();
        }

    }
}
