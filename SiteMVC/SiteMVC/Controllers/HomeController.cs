using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using SiteMVC.Constants;
using SiteMVC.Models;

namespace SiteMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        public ActionResult Home()
        {
            var photoDir = new DirectoryInfo(Server.MapPath("~/") + "\\Content\\homeImages");

            var photos = new List<PhotoItem>();
            foreach (var photoItem in photoDir.GetFiles("*.jpg"))
            {
                photos.Add(new PhotoItem
                {
                    Name = photoItem.Name,
                    Path = "/Content/homeImages/" + photoItem.Name,
                });
            }

            ViewBag.PhotosCount = photos.Count;
            ViewBag.Photos = photos;

            return View("Home");
        }


    }
}
