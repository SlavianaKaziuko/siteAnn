using System.Web.Mvc;

namespace SiteMVC.Controllers
{
    public class ResponsesController : Controller
    {
        //
        // GET: /Responses/

        public ActionResult Responses()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Responses");
            }

            ViewBag.Layout = "~/Views/_Layout.cshtml";
            return View();
        }

    }
}
