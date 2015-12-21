using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using SiteMVC.Models;

namespace SiteMVC.Controllers
{
    public class ServicesController : Controller
    {
        //
        // GET: /Services/

        public ActionResult Services(string type)
        {
            var portfolioDir = new DirectoryInfo(Server.MapPath("~/") + "\\Content\\services");
            var services = new List<Service>();
                var infoFile = new XmlDocument();
            if (System.IO.File.Exists(portfolioDir + @"\services.xml"))
            {
                infoFile.Load(portfolioDir.FullName + @"\services.xml");

                foreach (XmlNode service in infoFile.GetElementsByTagName("Service"))
                {
                    if (service.Attributes == null) continue;
                    var id = service.Attributes["id"].Value;
                    if (type!=null && id != type) continue;
                    var name = service.Attributes["name"].Value;
                    var path = "/Content/services/services_" + id + ".jpg";
                    var image = Image.FromFile(Server.MapPath(path));
                    var imageBase64 = "data:image/jpg;base64, ";
                    using (var ms = new MemoryStream())
                    {
                        // Convert Image to byte[]
                        image.Save(ms, image.RawFormat);
                        var imageBytes = ms.ToArray();

                        // Convert byte[] to Base64 String
                        imageBase64 += Convert.ToBase64String(imageBytes);
                    }

                    var packages = new List<Package>();
                    var xmlElement = service["Packages"];
                    if (xmlElement != null)
                        foreach (XmlNode package in xmlElement.ChildNodes)
                        {
                            var list = new List<string>();
                            if (package.Attributes == null) continue;
                            var rank = (PackageRank) Convert.ToInt32(package.Attributes["rank"].Value);
                            var packageName = rank == PackageRank.Mini
                                ? "Пакет «Мини»"
                                : rank == PackageRank.Standart
                                    ? "Пакет «Стандарт»"
                                    : rank == PackageRank.Super
                                        ? "Пакет «Супер»"
                                        : string.Empty;

                            list.AddRange(from XmlNode item in package.ChildNodes select item.InnerText);

                            packages.Add(new Package
                            {
                                Rank = rank,
                                Name = packageName,
                                ItemsList = list
                            });
                        }


                    services.Add(new Service
                    {
                        Id = id,
                        Name = name,
                        ImgPath = path,
                        ImgSource = imageBase64,
                        Packages = packages,
                        StylePackages = image.Height > image.Width ? "packageVertical" : "packageHorizontal",
                        ImgStyle = image.Height > image.Width ? "vertical" : ""
                    });
                }
            }

            ViewBag.ServiceList = services;

            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Services");
            }

            ViewBag.Layout = "~/Views/_Layout.cshtml";
            return View();
        }
    }
}
