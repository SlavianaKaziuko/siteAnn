using System.Collections.Generic;

namespace SiteMVC.Models
{
    public class Service
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Package> Packages { get; set; } 

        public string ImgPath { get; set; }

        public string ImgSource { get; set; }

        public string ImgStyle { get; set; }

        public string StylePackages { get; set; }
    }
}