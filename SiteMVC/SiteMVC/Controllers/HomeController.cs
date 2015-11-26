using System.Web.Mvc;

namespace SiteMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        public ActionResult Home()
        {
            return View("Home");
        }


    }
}
