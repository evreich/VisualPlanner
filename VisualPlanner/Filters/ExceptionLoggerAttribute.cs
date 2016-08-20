using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualPlanner.Models;

namespace VisualPlanner.Filters
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            ExceptionModel exceptionDetail = new ExceptionModel()
            {
                ExceptionMessage = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now
            };

            using (VisualPlannerContext db = new VisualPlannerContext())
            {
                db.Exceptions.Add(exceptionDetail);
                db.SaveChanges();
            }
            filterContext.Controller.ViewBag.Error = filterContext.Exception.Message;
            ViewResult vr = new ViewResult();
            vr.ViewName = "Error";
            vr.ViewBag.Error = filterContext.Exception.Message;
            filterContext.Result = vr;
            filterContext.ExceptionHandled = true;
        }
    }
}