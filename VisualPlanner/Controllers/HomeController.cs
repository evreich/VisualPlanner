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
using VisualPlanner.Models;

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
        [ExceptionLogger]
        public ActionResult Help(string email, string title, string comment)
        {
            MailAddress from = new MailAddress(ConfigurationManager.AppSettings["EmailSender"]);
            MailAddress to = new MailAddress(ConfigurationManager.AppSettings["EmailReceiver"]);
            MailMessage message = new MailMessage(from, to);
            message.Subject = title;
            message.Body = "<h2>E-mail отправителя: " + email + "</h2>" + "<p><b>Текст запроса: </b>" + comment + "</p>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailSender"], ConfigurationManager.AppSettings["SenderPass"]);
            smtp.EnableSsl = true;
            smtp.Send(message);
            ViewBag.SuccessSend = true;
            ViewBag.FixedFooter = false;
            return View();
        }
        /*
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
         * */

    }
}