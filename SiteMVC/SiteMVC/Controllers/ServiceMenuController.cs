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
    public class ServiceMenuController : Controller
    {
        public PartialViewResult ServiceMenu()
        {
            var portfolioDir = new DirectoryInfo(Server.MapPath("~/") + "\\Content\\services");
            var services = new List<Service>();
            var infoFile = new XmlDocument();
            if (System.IO.File.Exists(portfolioDir + @"\services.xml"))
            {
                infoFile.Load(portfolioDir.FullName + @"\services.xml");

                services.AddRange(from XmlNode service in infoFile.GetElementsByTagName("Service")
                    let xmlAttributeCollection = service.Attributes
                    where xmlAttributeCollection != null
                    where xmlAttributeCollection != null
                    let id = xmlAttributeCollection["id"].Value
                    let name = xmlAttributeCollection["name"].Value
                    select new Service
                    {
                        Id = id, Name = name,
                    });
            }

            return PartialView(services);
        }
    }
}