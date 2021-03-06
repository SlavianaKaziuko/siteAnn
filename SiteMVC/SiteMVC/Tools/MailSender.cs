﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using SiteMVC.Models;

namespace SiteMVC.Tools
{
    public static class MailSender
    {
        public static void SendContactMail(EmailModel model)
        {
            var message = new MailMessage
            {
                Subject = model.Subject,
                Body = String.Format("{0}.\n\nИмя - {1}\nТел - {2}\nEmail - {3}", model.Body, model.FromName, model.Telephone, model.From),
                IsBodyHtml = false
            };

            message.To.Add(model.To);
            var mailSettings = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            var mailClient = new SmtpClient(mailSettings.Network.Host, mailSettings.Network.Port)
            {
                Credentials = new NetworkCredential(mailSettings.Network.UserName, mailSettings.Network.Password),
                EnableSsl = mailSettings.Network.EnableSsl
            };

            message.From = new MailAddress(mailSettings.From);

            mailClient.Send(message);
        }
    }
}