using System;
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
                if (!System.IO.File.Exists(directoryInfo.FullName + @"\info.xml")) continue;
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

                album.Add(new AlbumItem
                {
                    Name = name,
                    Description = desc,
                    Path = path,
                    MainPhotoPath = "/Content/PortfolioContent/" + directoryInfo.Name + "/0.jpg"
                });
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
                using (var objImage = Image.FromFile(photoItem.FullName))
                {
                    var width = objImage.Width;
                    var height = objImage.Height;

                    var smallWidth = width > height
                        ? Constant.ImageWidth + "x" + Constant.ImageWidth*height/width
                        : (Constant.ImageHeight*width)/height + "x" + Constant.ImageHeight;

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
                        Style = style,
                        ImageSize = string.Empty
                    });
                }
            }

            const double galleryWidth = 1020.0 - 5;

            var firstOrDefault = photos.FirstOrDefault();
            if (firstOrDefault != null && (1.0 * firstOrDefault.Height / firstOrDefault.Width < 0.8))
            {
                firstOrDefault.Style = "photo-alone";
            }

            //if (!photos.Exists(i => i.Style == "photo-vertical"))
            //{
            //    var rnd = new Random();
            //    var index = rnd.Next(1, photos.Count - 2);
            //    var b = galleryWidth * photos[index].Height / (photos[index + 1].Height * photos[index].Width + photos[index].Height * photos[index + 1].Width);
            //    var a = b * photos[index + 1].Height / photos[index].Height;

            //    photos[index].ImageSize = "width: " + (int)(photos[index].Width * a) + "px;";
            //    photos[index].Style = "photo-item";
            //    photos[index + 1].ImageSize = "width: " + (int)(photos[index + 1].Width * b) + "px;";
            //    photos[index + 1].Style = "photo-item";
            //}

            for (var i = 1; i < photos.Count - 2; i++)
            {
                if (photos[i - 1].Style == "photo-horizontal" && photos[i].Style == "photo-horizontal" &&
                    photos[i + 1].Style == "photo-vertical" &&
                    photos[i + 2].Style == "photo-vertical")
                {
                    photos[i].Style = "photo-alone";
                }
            }

            for (var i = 1; i < photos.Count - 1; i++)
            {
                if (photos[i].Style == "photo-horizontal" && photos[i - 1].Style == "photo-horizontal" &&
                    photos[i + 1].Style == "photo-horizontal")
                {
                    photos[i].Style = "photo-alone";
                }
            }

            for (var i = 1; i < photos.Count; i++)
            {
                if (photos[i - 1].Style != "photo-alone")
                {
                    var b = galleryWidth * photos[i].Height / (photos[i - 1].Height * photos[i].Width + photos[i].Height * photos[i - 1].Width);
                    var a = b * photos[i - 1].Height / photos[i].Height;

                    photos[i].ImageSize = "width: " + (int)(photos[i].Width * a) + "px;";
                    photos[i].Style = "photo-item";
                    photos[i - 1].ImageSize = "width: " + (int)(photos[i - 1].Width * b) + "px;";
                    photos[i - 1].Style = "photo-item";
                    i++;
                }

                /*if (photos[i].Style == "photo-horizontal" && i + 1 < photos.Count && photos[i + 1].Style == "photo-horizontal")
                {
                    i++;
                }*/
            }

            ViewBag.Photos = photos;


            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Portfolio");
            }

            ViewBag.Layout = @"~/Views/_Layout.cshtml";
            return View("Portfolio");
        }

    }
}
