using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using VisualPlanner.Models;
using PagedList.Mvc;
using PagedList;

namespace VisualPlanner.Controllers
{
    [Authorize]
    public class OrganizerController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public OrganizerController()
        {
        }

        public OrganizerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

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

        // GET: Organizer
        public ActionResult Index()
        {
            //возможно параметр с выбранной датой
            ViewBag.PageTitle = "Расписание задач на сегодня";
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(TaskModel task, string period_type)
        {
            //возможно параметр с выбранной датой
            ViewBag.PageTitle = "Расписание задач на сегодня";
            if (ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Error = true;
            return View(task);
        }
        public ActionResult Calendar()
        {
            ViewBag.PageTitle = "Календарь";
            return View();
        }
        public ActionResult Projects()
        {
            ViewBag.PageTitle = "Проекты";
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Projects(TaskModel task)
        {
            //возможно параметр с выбранной датой
            ViewBag.PageTitle = "Проекты";
            if (ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Error = true;
            return View(task);
        }
        public ActionResult Search()
        {
            ViewBag.PageTitle = "Поиск задач";
            return View();
        }
        public ActionResult OldTasks(int? page)
        {
            ViewBag.PageTitle = "Неоконченные задачи";
            List<TaskModel> tasks = new List<TaskModel>();

            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №1", Status.During, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(2)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №2", Status.Done, Priority.Low, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №3", Status.Cancel, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(4)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №4", Status.Suspend, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(6)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №5", Status.During, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №1", Status.During, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(2)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №2", Status.Done, Priority.Low, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №3", Status.Cancel, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(4)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №4", Status.Suspend, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(6)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №5", Status.During, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now));

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(tasks.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult HotTasks(int? page)
        {
            ViewBag.PageTitle = "Оканчивающиеся задачи";
            List<TaskModel> tasks = new List<TaskModel>();

            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №1", Status.During, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(2)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №2", Status.Done, Priority.Low, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №3", Status.Cancel, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(4)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №4", Status.Suspend, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(6)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №5", Status.During, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №1", Status.During, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(2)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №2", Status.Done, Priority.Low, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №3", Status.Cancel, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(4)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №4", Status.Suspend, Priority.Medium, DateTime.Now.Subtract(TimeSpan.FromDays(6)), DateTime.Now));
            tasks.Add(new TaskModel(User.Identity.GetUserId(), "Задача №5", Status.During, Priority.High, DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now));

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(tasks.ToPagedList(pageNumber, pageSize));
        }
    }
}