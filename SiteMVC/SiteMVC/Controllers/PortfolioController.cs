using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using SiteMVC.Constants;
using SiteMVC.Models;

namespace SiteMVC.Controllers
{
    public class PortfolioController : Controller
    {
        //
        // GET: /Portfolio/

        public ActionResult Portfolio()
        {
            var portfolioDir = new DirectoryInfo(Server.MapPath("~/") + "\\Content\\PortfolioContent");
            var album = new List<AlbumItem>();
            foreach (var directoryInfo in portfolioDir.GetDirectories().Where(dir => dir.Name != "[Originals]"))
            {
                var infoFile = new XmlDocument();
                var path = directoryInfo.Name;
                infoFile.Load(directoryInfo.FullName + @"\info.xml");

                var nameElem = infoFile.GetElementsByTagName("Name").Item(0);
                var name = string.Empty;
                if (nameElem != null)
                {
                    name = nameElem.InnerText;
                }

                var descElem = infoFile.GetElementsByTagName("Description").Item(0);
                var desc = string.Empty;
                if (descElem != null)
                {
                    desc = descElem.InnerText;
                }

                album.Add(new AlbumItem { Name = name, Description = desc, Path = path, MainPhotoPath = "/Content/PortfolioContent/" + directoryInfo.Name + "/0.jpg" });
            }

            ViewBag.Album = album;
            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null; 
                return PartialView("Portfolio");
            }

            ViewBag.Layout = @"~/Views/_Layout.cshtml";
            return View();
        }

        public ActionResult Album(string path)
        {
            var photoDir = new DirectoryInfo(Server.MapPath("~/") + "\\Content\\PortfolioContent\\" + path);
            var infoFile = new XmlDocument();
            infoFile.Load(photoDir.FullName + @"\info.xml");

            var nameElem = infoFile.GetElementsByTagName("Name").Item(0);
            var nameOrig = string.Empty;
            if (nameElem != null)
            {
                nameOrig = nameElem.InnerText;
            }

            ViewBag.Name = nameOrig;

            var descElem = infoFile.GetElementsByTagName("Description").Item(0);
            var desc = string.Empty;
            if (descElem != null)
            {
                desc = descElem.InnerText;
            }

            ViewBag.Description = desc;

            var photos = new List<PhotoItem>();
            foreach (var photoItem in photoDir.GetFiles("*.jpg"))
            {
                using (Image objImage = Image.FromFile(photoItem.FullName))
                {
                    var width = objImage.Width;
                    var height = objImage.Height;

                    var smallWidth = width > height
                        ? Constant.ImageWidth + "x" + Constant.ImageWidth * height / width
                        : (Constant.ImageHeight * width) / height + "x" + Constant.ImageHeight;

                    var style = width > height
                        ? "photo-horizontal"
                        : "photo-vertical";

                    photos.Add(new PhotoItem
                    {
                        Name = photoItem.Name,
                        Path = "/Content/PortfolioContent/" + photoDir.Name + "/" + photoItem.Name,
                        Width = width,
                        Height = height,
                        Size = width + "x" + height,
                        SmallSize = smallWidth,
                        Style = style
                    });
                }
            }

            ViewBag.Photos = photos;

            return PartialView("Album");
        }

    }
}
