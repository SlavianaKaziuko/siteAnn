using System.Web.Mvc;

namespace SiteMVC.Controllers
{
    public class NewsController : Controller
    {        //
        // GET: /News/

        public ActionResult News()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("News");
            }

            ViewBag.Layout = @"~/Views/_Layout.cshtml";
            return View();
        }

    }
}