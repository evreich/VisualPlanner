using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using VisualPlanner.Filters;
using VisualPlanner.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace VisualPlanner.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            ViewBag.FixedFooter = false;
            return View();
        }
        [HttpGet]
        public ActionResult Help()
        {
            ViewBag.FixedFooter = false;
            var userId = User.Identity.GetUserId();
            
            if (userId != null)
            {
                var user = UserManager.FindById(userId);
                if (user != null)
                    ViewBag.Email = user.Email;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionLogger]
        public ActionResult Help(HelpViewModel query)
        {
            ViewBag.FixedFooter = false;
            if (ModelState.IsValid)
            {
                MailAddress from = new MailAddress(ConfigurationManager.AppSettings["EmailSender"]);
                MailAddress to = new MailAddress(ConfigurationManager.AppSettings["EmailReceiver"]);
                MailMessage message = new MailMessage(from, to);
                message.Subject = query.Title;
                message.Body = "<h2>E-mail отправителя: " + query.Email + "</h2>" + "<p><b>Текст запроса: </b>" + query.Comment + "</p>";
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailSender"], ConfigurationManager.AppSettings["SenderPass"]);
                smtp.EnableSsl = true;
                smtp.Send(message);
                ViewBag.SuccessSend = true;
                return View();
            }
            ViewBag.SuccessSend = false;
            return View(query);
        }

    }
}