using System.Web.Mvc;

namespace SiteMVC.Areas._Default.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /_Default/Contacts/

        public ActionResult Contacts()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Contacts");
            }

            ViewBag.Layout = "~/Areas/_Default/Views/_Layout.cshtml";
            return View();
        }
    }
}
