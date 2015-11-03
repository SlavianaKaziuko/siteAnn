﻿using System;
using System.Net.Mail;
using System.Web.Mvc;
using SiteMVC.Models;
using SiteMVC.Tools;

namespace SiteMVC.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /_Default/Contacts/

        public ActionResult Contacts()
        {
            ViewBag.ModelEmail = new EmailModel();

            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Contacts");
            }

            ViewBag.Layout = "~/Views/_Layout.cshtml";
            return View();
        }

        [HttpPost]
        public ActionResult SendMeEmail(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailSender.SendContactMail(model);
                    model.Success = true;
                }
                catch (SmtpException)
                {
                    model.Success = false;
                }
                
            }

            if (Request.IsAjaxRequest())
            {
                ViewBag.Layout = null;
                return PartialView("Contacts");
            }

            ViewBag.Layout = "~/Views/_Layout.cshtml";
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
