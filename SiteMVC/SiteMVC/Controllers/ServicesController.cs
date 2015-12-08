using System;
using System.Collections.Generic;
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

        public ActionResult Services()
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
                    var name = service.Attributes["name"].Value;;
                    var path = "/Content/services/services_" + id + ".jpg";

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
                        ImgSource = path,
                        Packages = packages
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
