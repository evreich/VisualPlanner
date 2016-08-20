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
            return View();
        }
    }
}