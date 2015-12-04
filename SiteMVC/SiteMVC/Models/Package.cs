using System.Collections.Generic;

namespace SiteMVC.Models
{
    public class Package
    {
        public PackageRank Rank { get; set; }

        public string Name { get; set; }

        public List<string> ItemsList { get; set; } 
    }
}