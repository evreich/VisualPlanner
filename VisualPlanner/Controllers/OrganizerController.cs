using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisualPlanner.Controllers
{
    [Authorize]
    public class OrganizerController : Controller
    {
        // GET: Organizer
        public ActionResult Index()
        {
            //возможно параметр с выбранной датой
            ViewBag.PageTitle = "Расписание задач на сегодня";
            return View();
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
        public ActionResult Search()
        {
            ViewBag.PageTitle = "Поиск задач";
            return View();
        }
        public ActionResult OldTasks()
        {
            ViewBag.PageTitle = "Неоконченные задачи";
            return View();
        }
        public ActionResult HotTasks()
        {
            ViewBag.PageTitle = "Оканчивающиеся задачи";
            return View();
        }
    }
}