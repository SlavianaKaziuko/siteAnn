using System.Collections.Generic;
using System.Web.Mvc;
using SiteMVC.Areas._Default.Models;

namespace SiteMVC.Areas._Default.Controllers
{
    public class HomeController : Controller
    {
        // GET: /_Default/Home/

        public ActionResult Home()
        {
            var photos = new List<PhotoItem>();
            for (var i = 1; i < 13; i++)
            {
                photos.Add(new PhotoItem { Name = i + ".jpg", Path = "/Portfolio/" + i + ".jpg" });
            }

            ViewBag.Photos = photos;

            return View("Home");
        }


    }
}
