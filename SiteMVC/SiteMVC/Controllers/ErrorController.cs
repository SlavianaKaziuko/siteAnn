using System.Web.Mvc;

namespace SiteMVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View("Error");
        }

    }
}