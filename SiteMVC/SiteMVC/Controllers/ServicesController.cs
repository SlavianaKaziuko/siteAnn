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
                    var xmlElement = service.FirstChild["Packages"];
                    if (xmlElement != null)
                        foreach (XmlNode package in xmlElement.ChildNodes)
                        {
                            packages.Add(new Package
                            {
                                
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
