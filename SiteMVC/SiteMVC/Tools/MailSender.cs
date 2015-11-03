using System;
using System.Configuration;
using System.Configuration.Internal;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;
using Newtonsoft.Json;
using SiteMVC.Models;

namespace SiteMVC.Tools
{
    public static class MailSender
    {
        public static void SendContactMail(EmailModel model)
        {
            
            var client = new SmtpClient();

            var message = new MailMessage
            {
                Subject = model.Subject,
                //From = new MailAddress(model.From, model.FromName),
                Body = String.Format("{0}. Sent from {1}", model.Body, model.From),
                IsBodyHtml = false
            };

            message.To.Add(model.To);

            client.Credentials = new NetworkCredential("username@domain.com", "pwd");
            client.Port = 465;
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}