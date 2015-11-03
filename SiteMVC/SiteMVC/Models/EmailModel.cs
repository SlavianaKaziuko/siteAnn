using System.Configuration;

namespace SiteMVC.Models
{
    public class EmailModel
    {
        public string Subject { get; set; }

        public string From { get; set; }

        public string FromName { get; set; }

        public string Telephone { get; set; }

        public string To { get; set; }

        public string Body { get; set; }

        public bool Success { get; set; }

        public EmailModel()
        {
            Success = false;

            Subject = ConfigurationManager.AppSettings["ContactUsTheme"];
            To = ConfigurationManager.AppSettings["ContactUsToEmail"];
            From = string.Empty;
            FromName = string.Empty;
            Body = string.Empty;
        }
    }
}