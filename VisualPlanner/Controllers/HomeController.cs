using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using VisualPlanner.Models;

namespace VisualPlanner.Controllers
{
    public class HomeController : Controller
    {
        const string MailSender = "vlasov_godlike312@mail.ru";
        const string MailReceiver = "vlasov_ms@list.ru";
        const string MailPassword = "grinvelgodlike312";
        VisualPlannerContext db = new VisualPlannerContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Help()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Help(string email, string title, string comment)
        {
            MailAddress from = new MailAddress(MailSender);
            MailAddress to = new MailAddress(MailReceiver);
            MailMessage message = new MailMessage(from, to);
            message.Subject = title;
            message.Body = "<h2>E-mail отпавителя: "+email+"</h2>"+"<p><b>Запрос: </b>"+comment+"</p>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential(MailSender, MailPassword);
            smtp.EnableSsl = true;
            smtp.Send(message);
            ViewBag.ShowAlert = true;
            return View();
        }
    }
}