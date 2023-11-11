using System;
using System.Web.Mvc;

namespace WebMvc.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxOnlyAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 404;
                filterContext.Result = new HttpNotFoundResult();
            } else
            {
                base.OnActionExecuting(filterContext);
            }            
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.Result = new JsonResult
            {
                Data = new { success = false, error = filterContext.Exception.Message.ToString() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}