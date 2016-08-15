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
            if(exceptionDetail.ActionName=="Help")
                filterContext.Result = new RedirectResult("/Error/SendError");
            filterContext.ExceptionHandled = true;
        }
    }
}