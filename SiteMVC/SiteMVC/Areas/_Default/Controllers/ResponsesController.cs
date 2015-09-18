using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMVC.Areas._Default.Controllers
{
    public class ResponsesController : Controller
    {
        //
        // GET: /_Default/Responses/

        public ActionResult Responses()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Responses");
            }

            ViewBag.Layout = "~/Areas/_Default/Views/_Layout.cshtml";
            return View();
        }

    }
}
