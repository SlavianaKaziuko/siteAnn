using System.Collections.Generic;
using System.Drawing;

namespace SiteMVC.Models
{
    public class Service
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Package> Packages { get; set; } 

        public string ImgPath { get; set; }

        public Image ImgSource { get; set; }
    }
}